using ConsoleApp1.DTOs.Device;

namespace ConsoleApp1.Interfaces.Services;

public interface IDeviceService
{
    int CreateDevice(CreateDeviceDTO dto);
}