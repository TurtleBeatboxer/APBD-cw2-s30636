namespace ConsoleApp1.DTOs.Device;

public class ProjectorDto : DeviceDTO
{
    public string LightLumen { get; set; }
    public bool IsWiFi { get; set; } 
}

public class CreateProjectorDTO : CreateDeviceDTO
{
    public string LightLumen { get; set; }
    public bool IsWiFi { get; set; }
}