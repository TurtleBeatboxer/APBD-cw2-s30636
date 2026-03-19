using ConsoleApp1.DTOs;

namespace ConsoleApp1.DTOs.Device;

public class CameraDTO : DeviceDTO
{
    public string LenseBrand { get; set; }
    public int MaxZoomLevel { get; set; }  
}
public class CreateCameraDTO : CreateDeviceDTO
{
    public string LenseBrand { get; set; }
    public int MaxZoomLevel { get; set; }
}