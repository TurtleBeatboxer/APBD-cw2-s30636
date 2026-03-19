namespace ConsoleApp1;

public abstract class Device
{
    private static int _idCount; 
    public int Id { get; private set; }
    
    private string Name { get; set; }
    private string AvailabilityStatus { get; set; }
    private string RentalPrice { get; set; }
    private DateTimeOffset RentalDate { get; set; }
    private string Serial {get; set;}
    
    protected Device(string name, string serial, string rentalPrice)
    {
        Id = ++_idCount;
        Name = name;
        Serial = serial;
        RentalPrice = rentalPrice;
    }
}