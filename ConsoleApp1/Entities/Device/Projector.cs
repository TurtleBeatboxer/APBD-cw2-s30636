namespace ConsoleApp1;

public class Projector : Device
{
   public string LightLumen {get; private set;}
   public bool IsWiFi {get; private set;}
   
   public Projector(string name, string serial, Double rentalPrice, string lightLumen, bool isWiFi) 
      : base(name, serial, rentalPrice)
   {
      LightLumen = lightLumen;
      IsWiFi = isWiFi;
   }
}