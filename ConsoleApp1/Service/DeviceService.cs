namespace ConsoleApp1.Service;

public class DeviceService
{
    private static List<Device> _devices;

    public static void addDevice(Device device)
    {
        _devices.Add(device);
    }
    

    public static void PrintAllDeviceswithTheirAvailableStatus()
    {
        Console.WriteLine(_devices.);
    }
}