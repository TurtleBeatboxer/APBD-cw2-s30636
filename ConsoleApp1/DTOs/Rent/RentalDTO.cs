using ConsoleApp1.DTOs.Device;
using ConsoleApp1.DTOs.User;

namespace ConsoleApp1.DTOs.Rent;

public class RentalDto
{
    public UserDTO User { get; set; }
    public DeviceDTO Device { get; set; }
    public DateTimeOffset DateOfRental { get; set; }
    public DateTimeOffset DateOfReturn { get; set; }
    public bool IsReturnOnTime { get; set; }
}

public class CreateRentalDto
{
    public int UserId { get; set; }
    public int DeviceId { get; set; }
    public DateTimeOffset DateOfRental { get; set; }
    public DateTimeOffset DateOfReturn { get; set; }
}