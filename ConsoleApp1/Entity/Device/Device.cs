namespace ConsoleApp1;

public abstract class Device
{
    private static int _idCount; 
    private int Id { get; }
    
    private string Name { get; set; }
    private string AvailabilityStatus { get; set; }
    private string RentalPrice { get; set; }
    private DateTimeOffset RentalDate { get; set; }
    private string Serial {get; set;}
    
    public Device()
    {
        Id = ++_idCount;
    }
}