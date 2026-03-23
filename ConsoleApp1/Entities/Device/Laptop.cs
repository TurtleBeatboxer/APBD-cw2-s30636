namespace ConsoleApp1;

public class Laptop : Device
{
    public string GPUModel {get; private set;}
    public string Model {get; private set;}
    public string CPUModel { get; private set; }
    
    public Laptop(string name, string serial, Double rentalPrice, string gpuModel, string model, string cpuModel) 
        : base(name, serial, rentalPrice)
    {
        GPUModel = gpuModel;
        Model = model;
        CPUModel = cpuModel;
    }
}