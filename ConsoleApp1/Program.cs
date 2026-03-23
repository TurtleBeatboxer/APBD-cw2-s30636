// See https://aka.ms/new-console-template for more information

using ConsoleApp1.DTOs.Device;
using ConsoleApp1.DTOs.Rent;
using ConsoleApp1.DTOs.User;
using ConsoleApp1.Entities.Enum;
using ConsoleApp1.Repositories;
using ConsoleApp1.Service;
using ConsoleApp1.Services;

namespace ConsoleApp1;

public class Program
{
    public static void Main(string[] args)
    {
        var deviceRepository = new DeviceRepository();
        var deviceService = new DeviceService(deviceRepository);

        var userRepository = new UserRepository();
        var userService = new UserService(userRepository);

        var rentalRepository = new RentalRepository();
        var rentalService = new RentalService(rentalRepository, userRepository, deviceRepository);


        var newStudentDto = new CreateStudentDTO
        {
            Username = "TurtleBeaatboxer",
            Name  = "Michal",
            Lastname  = "Marzecki",
        };
        var newEmployeeDto = new CreateEmployeeDTO
        {
            Username = "ProfKowalski",
            Name = "Jan",
            Lastname = "Kowalski"
        };

        int studentId = 0;
        int employeeId = 0;
        try 
        {
            // 1. First functionality
           studentId = userService.CreateUser(newStudentDto);
           employeeId = userService.CreateUser(newEmployeeDto);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }


        int laptop1Id = 0;
        int laptop2Id = 0;
        int cameraId = 0; 
        var newLaptopDto = new CreateLaptopDTO { Name = "ThinkPad T14", Serial = "TP-12345", RentalPrice = 50.00, 
            GPUModel = "Integrated Intel", Model = "T14 Gen 3", CPUModel = "Intel i7" };
        var newLaptopNextDto = new CreateLaptopDTO { Name = "ThinkPad T15", Serial = "TP-23456", RentalPrice = 51.00, 
            GPUModel = "Integrated Intel", Model = "T15 Gen 4", CPUModel = "Intel i7" };
        var newCameraDto = new CreateCameraDTO { Name = "Sony A7 III", Serial = "SNY-999", RentalPrice = 120.00, 
            LenseBrand = "Sony", MaxZoomLevel = 2 };

        try 
        {
            // 2. Second Functionality
            laptop1Id = deviceService.CreateDevice(newLaptopDto);
            laptop2Id = deviceService.CreateDevice(newLaptopNextDto);
            cameraId = deviceService.CreateDevice(newCameraDto);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        
        // 3. Third Functionality
        foreach (var device in deviceService.GetAllDevices())
        {
            Console.WriteLine($"Device: {device.Name} with ID:{device.Id} is {device.Status}");
        }

        // 5. Fifth functionality
        var rent1 = new CreateRentalDTO { UserId = studentId, DeviceId = laptop1Id, DateOfRental = DateTimeOffset.Now,
            PlannedDateOfReturn = DateTimeOffset.Now.AddDays(7) };
        int rental1Id = rentalService.RentDevice(rent1);
        
        // 4. Fourth Functionality
        foreach (var device in deviceService.GetAllDevices(DeviceStatus.Available))
        {
            Console.WriteLine($"Device: {device.Name} with ID:{device.Id} is {device.Status}");
        }
        
        var rent2 = new CreateRentalDTO { UserId = studentId, DeviceId = laptop2Id, DateOfRental = DateTimeOffset.Now.AddDays(-5),
            PlannedDateOfReturn = DateTimeOffset.Now.AddDays(-1) };
        int rental2Id = rentalService.RentDevice(rent2);

        try 
        {
            Console.WriteLine("\nAttempting to rent a 3rd device (should fail)...");
            var rent3 = new CreateRentalDTO { UserId = studentId, DeviceId = cameraId, DateOfRental = DateTimeOffset.Now, 
                PlannedDateOfReturn = DateTimeOffset.Now.AddDays(7) };
            rentalService.RentDevice(rent3);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[EXPECTED FAILURE]: {ex.Message}");
        }
        
        // 6th functionality
        decimal fee1 = rentalService.ReturnDevice(rental1Id);
        Console.WriteLine($"Returned Laptop 1 on time. Penalty fee: {fee1}");

        decimal fee2 = rentalService.ReturnDevice(rental2Id);
        Console.WriteLine($"Returned Laptop 2 late. Penalty fee applied: {fee2}");

        // 7th functionality 
        deviceService.MarkAsUnavailableById(cameraId);

        // 8th functionality
        var activeRentals = rentalService.GetActiveRentalsForUser(studentId);
        if (!activeRentals.Any())
        {
            Console.WriteLine("This user has no active rentals.");
        }
        foreach (var rental in activeRentals)
        {
            Console.WriteLine($"Device: {rental.Device.Name} (ID: {rental.Device.Id}) Due back: {rental.PlannedReturnDate:yyyy-MM-dd}");
        }

        // 9th functionality 
        var overdueRentals = rentalService.GetOverdueRentals();
        if (!overdueRentals.Any())
        {
            Console.WriteLine("There are no overdue rentals right now.");
        }
        foreach (var rental in overdueRentals)
        {
            var lateDays = (DateTimeOffset.Now - rental.PlannedReturnDate).Days;
            Console.WriteLine($"Device: {rental.Device.Name} (ID: {rental.Device.Id}) Rented by ID: {rental.User.Id} {lateDays} days late");
        }

        // 10th functionality
        Console.WriteLine(rentalService.GenerateSystemReport());
    }
}