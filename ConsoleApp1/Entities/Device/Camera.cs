namespace ConsoleApp1;

public class Camera : Device
{
    public string LenseBrand {get; private set;}
    public int MaxZoomLevel {get; private set;}

    public Camera(string name, string serial, Double rentalPrice, string lenseBrand, int maxZoomLevel) 
        : base(name, serial, rentalPrice)
    {
        LenseBrand = lenseBrand;
        MaxZoomLevel = maxZoomLevel;
    }
}