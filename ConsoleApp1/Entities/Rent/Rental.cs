namespace ConsoleApp1.Entity.Rent;

public class Rental
{
    private User User {get; set;}
    private Device Device {get; set;}
    private DateTimeOffset DateOfRental {get; set;}
    private DateTimeOffset DateOfReturn {get; set;}
    private bool IsReturnOnTime {get; set;}
    
    public Rental(User user, Device device, DateTimeOffset dateOfRental, DateTimeOffset dateOfReturn)
    {
        User = user;
        Device = device;
        DateOfRental = dateOfRental;
        DateOfReturn = dateOfReturn;
        IsReturnOnTime = false; 
    }
}