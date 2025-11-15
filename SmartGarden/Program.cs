namespace SmartGarden;

class Program
{
    static void Main(string[] args)
    {
        var garden = new Garden(new SoilMoistureSensor(), new WeatherService());

        garden.AddPlant(new Flower("Rose", 25));
        garden.AddPlant(new Vegetable("Tomato", 20));
        garden.AddPlant(new Tree("Oak", 15));

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== SMART GARDEN SIMULATOR ===\n");
            Console.WriteLine(garden.GetStatus());

            Console.WriteLine("\n1. Simulate day");
            Console.WriteLine("2. Show log");
            Console.WriteLine("3. Exit");
            Console.Write("Choose: ");

            var key = Console.ReadKey().Key;
            Console.WriteLine("\n");

            switch (key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    garden.SimulateDay();
                    Console.WriteLine(garden.GenerateReport()); // ← TYLKO TU!
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    break;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    Console.WriteLine("=== LOG ===");
                    foreach (var log in garden.Log)
                        Console.WriteLine(log);
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    break;

                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    Console.WriteLine("Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid choice! Press any key...");
                    Console.ReadKey();
                    break;
            }
        }
    }
}