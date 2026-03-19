namespace ConsoleApp1;

public class Laptop : Device
{
    private string GPUModel {get; set;}
    private string Model {get; set;}
    private string CPUModel { get;  set; }
    
    public Laptop(string name, string serial, string rentalPrice, string gpuModel, string model, string cpuModel) 
        : base(name, serial, rentalPrice)
    {
        GPUModel = gpuModel;
        Model = model;
        CPUModel = cpuModel;
    }
}