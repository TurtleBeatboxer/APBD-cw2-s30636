using ConsoleApp1.Entities.Enum;

namespace ConsoleApp1;

public abstract class Device
{
    private static int _idCount; 
    public int Id { get; }
    
    public string Name { get; private set; }
    public string Serial { get; private set; }
    public Double RentalPrice { get; private set; }
    public DeviceStatus Status { get; private set; } 
    protected Device(string name, string serial, Double rentalPrice)
    {
        Id = ++_idCount;
        Name = name;
        Serial = serial;
        RentalPrice = rentalPrice;
        Status = DeviceStatus.Available; 
    }
    
    public void MarkAsRented()
    {
        Status = DeviceStatus.Rented;
    }

    public void MarkAsAvailable()
    {
        Status = DeviceStatus.Available;
    }

    public void MarkAsUnavailable()
    {
        Status = DeviceStatus.Unavailable;
    }
}