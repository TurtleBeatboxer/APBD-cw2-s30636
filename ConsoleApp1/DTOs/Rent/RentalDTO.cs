using ConsoleApp1.DTOs.Device;
using ConsoleApp1.DTOs.User;

namespace ConsoleApp1.DTOs.Rent;

public class RentalDTO
{
    public UserDTO User { get; set; }
    public DeviceDTO Device { get; set; }
    public DateTimeOffset DateOfRental { get; set; }
    public DateTimeOffset PlannedReturnDate { get; set; }
    public DateTimeOffset? DateOfReturn { get; set; }
    public Decimal PenaltyFee { get; set; }
    public bool IsActive;
    public bool WasReturnedOnTime;
    public int Id { get; private set; }
}

public class CreateRentalDTO
    {
        public int UserId { get; set; }
        public int DeviceId { get; set; }
        public DateTimeOffset DateOfRental { get; set; }
        public DateTimeOffset PlannedDateOfReturn { get; set; }
    }

