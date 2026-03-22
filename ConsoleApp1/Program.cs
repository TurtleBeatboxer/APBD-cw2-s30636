// See https://aka.ms/new-console-template for more information

using ConsoleApp1.DTOs.Device;
using ConsoleApp1.DTOs.User;
using ConsoleApp1.Repositories;
using ConsoleApp1.Service;
using ConsoleApp1.Services;

var deviceRepository = new DeviceRepository();
var deviceService = new DeviceService(deviceRepository);

var userRepository = new UserRepository();
var userService = new UserService(userRepository);

var rentalRepository = new RentalRepository();
var rentalService = new RentalService(rentalRepository, userRepository, deviceRepository);

var newStudentDTO = new CreateStudentDTO
{
    Username = "TurtleBeaatboxer",
    Name  = "Michal",
    Lastname  = "Marzecki",
};


try 
{
    userService.CreateUser(newStudentDTO);
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}



var newLaptopDto = new CreateLaptopDTO
{
    Name = "ThinkPad T14",
    Serial = "TP-12345",
    RentalPrice = 50.00,
    GPUModel = "Integrated Intel",
    Model = "T14 Gen 3",
    CPUModel = "Intel i7"
};

try 
{
    int newId = deviceService.CreateDevice(newLaptopDto);
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}