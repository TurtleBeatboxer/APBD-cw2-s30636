namespace ConsoleApp1.DTOs.Device;

public class LaptopDTO : DeviceDTO
{
    public string GPUModel { get; set; }
    public string Model { get; set; }
    public string CPUModel { get; set; }
}

public class CreateLaptopDTO : CreateDeviceDTO
{
    public string GPUModel { get; set; }
    public string Model { get; set; }
    public string CPUModel { get; set; }
}