namespace ConsoleApp1.DTOs.Device;

public abstract class DeviceDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string AvailabilityStatus { get; set; }
    
    public string RentalPrice { get; set; } 
    
    public DateTimeOffset RentalDate { get; set; }
    public string Serial { get; set; }
}

public abstract class CreateDeviceDTO
{
    public string Name { get; set; }
    public string RentalPrice { get; set; }
    public string Serial { get; set; }
}