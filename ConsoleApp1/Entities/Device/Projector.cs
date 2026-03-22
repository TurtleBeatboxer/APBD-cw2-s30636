namespace ConsoleApp1;

public class Projector : Device
{
   private string LightLumen {get; set;}
   private bool IsWiFi {get; set;}
   
   public Projector(string name, string serial, Double rentalPrice, string lightLumen, bool isWiFi) 
      : base(name, serial, rentalPrice)
   {
      LightLumen = lightLumen;
      IsWiFi = isWiFi;
   }
}