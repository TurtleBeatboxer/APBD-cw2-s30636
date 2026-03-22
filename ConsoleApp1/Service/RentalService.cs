using ConsoleApp1.DTOs.Rent;
using ConsoleApp1.Entities.Enum;
using ConsoleApp1.Entity.Rent;
using ConsoleApp1.Repositories;

namespace ConsoleApp1.Services;

public class RentalService
{
    private readonly RentalRepository _rentalRepository;
    private readonly UserRepository _userRepository;
    private readonly DeviceRepository _deviceRepository;

    public RentalService(RentalRepository rentalRepo, UserRepository userRepo, DeviceRepository deviceRepo)
    {
        _rentalRepository = rentalRepo;
        _userRepository = userRepo;
        _deviceRepository = deviceRepo;
    }

    public int RentDevice(CreateRentalDTO dto)
    {
        var user = _userRepository.GetById(dto.UserId);
        var device = _deviceRepository.GetById(dto.DeviceId);
        
        if (device.Status != DeviceStatus.Available)
        {
            throw new InvalidOperationException($"Device {device.Name} is currently unavailable.");
        }


        int activeRentals = _rentalRepository.GetActiveRentalCountForUser(user.Id);
        int maxAllowed = user switch
        {
            Student => 2,
            Employee => 5,
            _ => 0
        };

        if (activeRentals >= maxAllowed)
        {
            throw new InvalidOperationException($"User has reached their maximum rental limit of {maxAllowed}.");
        }
        
        var rental = new Rental(user, device, dto.DateOfRental, dto.DateOfReturn);
        
        device.MarkAsRented(); 

        _rentalRepository.Add(rental);
        return rental.Id;
    }

    public decimal ReturnDevice(int rentalId)
    {
        var rental = _rentalRepository.GetById(rentalId);

        if (!rental.IsActive)
            throw new InvalidOperationException("This rental has already been returned.");
        
        decimal penaltyFee = 0;
        var actualReturnDate = DateTimeOffset.Now;
        if (actualReturnDate > rental.PlannedReturnDate)
        {
            var lateDays = (actualReturnDate - rental.PlannedReturnDate).Days;
            penaltyFee = lateDays * 10.0m; 
        }
        
        rental.MarkAsReturned(actualReturnDate, penaltyFee);
        rental.Device.MarkAsAvailable();

        return penaltyFee; 
    }
}