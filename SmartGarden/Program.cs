namespace SmartGarden;

class Program
{
    static void Main(string[] args)
    {
        var garden = new Garden(new SoilMoistureSensor(), new WeatherService());
        garden.AddPlant(new Flower("Rose", 25));
        garden.AddPlant(new Vegetable("Tomato", 20));

        Console.WriteLine("=== BEFORE ===");
        Console.WriteLine(garden.GetStatus());

        garden.SimulateDay();

        Console.WriteLine("\n=== AFTER ===");
        Console.WriteLine(garden.GetStatus());
        Console.WriteLine(garden.GenerateReport());
    }
}