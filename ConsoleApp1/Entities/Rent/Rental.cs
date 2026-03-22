namespace ConsoleApp1.Entity.Rent;

public class Rental
{
    public User User {get; private set;}
    public Device Device {get; private set;}
    public DateTimeOffset DateOfRental {get; private set;}
    public DateTimeOffset PlannedReturnDate { get; private set; }
    private DateTimeOffset? DateOfReturn { get; set; }
    public Decimal PenaltyFee {get; private set;}
    public bool IsActive => DateOfReturn == null;
    public bool WasReturnedOnTime => DateOfReturn.HasValue && DateOfReturn.Value <= PlannedReturnDate;    
    
    private static int _idCount; 
    public  int Id { get; private set; }
    
    public Rental(User user, Device device, DateTimeOffset dateOfRental, DateTimeOffset PlannedDateOfReturn)
    {
        Id = ++_idCount;
        User = user;
        Device = device;
        DateOfRental = dateOfRental;
        PlannedReturnDate = PlannedDateOfReturn;
    }

    public void MarkAsReturned(DateTimeOffset dateOfReturn, decimal penaltyFee)
    {
        DateOfReturn = dateOfReturn;
        PenaltyFee = penaltyFee;
    }
}