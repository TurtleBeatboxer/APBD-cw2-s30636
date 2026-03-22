namespace ConsoleApp1;

public class Camera : Device
{
    private string LenseBrand {get; set;}
    private int MaxZoomLevel {get; set;}

    public Camera(string name, string serial, Double rentalPrice, string lenseBrand, int maxZoomLevel) 
        : base(name, serial, rentalPrice)
    {
        LenseBrand = lenseBrand;
        MaxZoomLevel = maxZoomLevel;
    }
}