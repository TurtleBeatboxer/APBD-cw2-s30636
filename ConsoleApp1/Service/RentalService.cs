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
    
    private const int MaxStudentRentals = 2;
    private const int MaxEmployeeRentals = 5;
    private const decimal DailyPenaltyRate = 10.0m;

    public RentalService(RentalRepository rentalRepo, UserRepository userRepo, DeviceRepository deviceRepo) {
        _rentalRepository = rentalRepo;
        _userRepository = userRepo;
        _deviceRepository = deviceRepo;
    }

    public int RentDevice(CreateRentalDTO dto) {
        var user = _userRepository.GetById(dto.UserId);
        var device = _deviceRepository.GetById(dto.DeviceId);
        
        if (device.Status != DeviceStatus.Available)
        {
            throw new InvalidOperationException($"Device {device.Name} is currently unavailable.");
        }


        int activeRentals = _rentalRepository.GetActiveRentalCountForUser(user.Id);
        int maxAllowed = user switch
        {
            Student => MaxStudentRentals,
            Employee => MaxEmployeeRentals,
            _ => 0
        };

        if (activeRentals >= maxAllowed)
        {
            throw new InvalidOperationException($"User has reached their maximum rental limit of {maxAllowed}.");
        }
        
        var rental = new Rental(user, device, dto.DateOfRental, dto.PlannedDateOfReturn);
        
        device.MarkAsRented(); 

        _rentalRepository.Add(rental);
        return rental.Id;
    }

    public decimal ReturnDevice(int rentalId) {
        var rental = _rentalRepository.GetById(rentalId);

        if (!rental.IsActive)
            throw new InvalidOperationException("This rental has already been returned.");
        
        decimal penaltyFee = 0;
        var actualReturnDate = DateTimeOffset.Now;
        if (actualReturnDate > rental.PlannedReturnDate)
        {
            var lateDays = (actualReturnDate - rental.PlannedReturnDate).Days;
            penaltyFee = lateDays * DailyPenaltyRate; 
        }
        
        rental.MarkAsReturned(actualReturnDate, penaltyFee);
        rental.Device.MarkAsAvailable();

        return penaltyFee; 
    }
    
    public IEnumerable<Rental> GetActiveRentalsForUser(int userId) {
        return _rentalRepository.GetActiveRentalsForUser(userId);
    }

    public IEnumerable<Rental> GetOverdueRentals() {
        return _rentalRepository.GetOverdueRentals(DateTimeOffset.Now);
    }

    public string GenerateSystemReport() {
        var allDevices = _deviceRepository.GetAll().ToList();
        var allUsers = _userRepository.GetAll().ToList();
        var allRentals = _rentalRepository.GetAll().ToList();
        var currentDate = DateTimeOffset.Now;

        int totalDevices = allDevices.Count;
        int availableDevices = allDevices.Count(d => d.Status == DeviceStatus.Available);
        int rentedDevices = allDevices.Count(d => d.Status == DeviceStatus.Rented);
        int unavailableDevices = allDevices.Count(d => d.Status == DeviceStatus.Unavailable);

        int activeRentals = allRentals.Count(r => r.IsActive);
        int overdueRentals = _rentalRepository.GetOverdueRentals(currentDate).Count();
        decimal totalPenaltiesCollected = allRentals.Sum(r => r.PenaltyFee);

        return $"""
                [System Status]
                Registered users: {allUsers.Count}
                Devices total: {totalDevices} (Available: {availableDevices}, Rented: {rentedDevices}, Unavailable: {unavailableDevices})
                Active rentals: {activeRentals}
                Overdue rentals: {overdueRentals}
                Total penalty fees collected: {totalPenaltiesCollected} PLN
                [End of System Status]
                """;
    }
}