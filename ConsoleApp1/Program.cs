// See https://aka.ms/new-console-template for more information

using ConsoleApp1.DTOs.Device;
using ConsoleApp1.Repositories;
using ConsoleApp1.Service;

var deviceRepository = new DeviceRepository();
var deviceService = new DeviceService(deviceRepository);

var newLaptopDto = new CreateLaptopDTO
{
    Name = "ThinkPad T14",
    Serial = "TP-12345",
    RentalPrice = "50.00",
    GPUModel = "Integrated Intel",
    Model = "T14 Gen 3",
    CPUModel = "Intel i7"
};

try 
{
    int newId = deviceService.CreateDevice(newLaptopDto);
    Console.WriteLine($"Successfully created Laptop with ID: {newId}");
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}