namespace SmartGarden;

public class Garden
{
    private readonly List<Plant> _plants;
    private readonly ISensor<double> _soilSensor;
    private readonly IWeather _weather;
    private readonly List<string> _log;
    public IReadOnlyList<string> Log => _log;

    private int _irrigatedToday;

    public Garden(ISensor<double> soilSensor, IWeather weather)
    {
        _plants = new List<Plant>();
        _log = new List<string>();
        _weather = weather;
        _soilSensor = soilSensor;
    }

    public void AddPlant(Plant plant)
    {
        if (plant == null)
        {
            throw new ArgumentNullException("Plant cannot be null");
        }
        
        _plants.Add(plant);
        _log.Add($"Added plant: {plant.Name}");
    }

    public void SimulateDay()
    {
        _irrigatedToday = 0;

        double temp = _weather.GetTemperature();
        double rain = _weather.GetPrecipitation();
        _log.Add($"Day simulated: Temp {temp:F1}°C, Rain {rain:F1}mm");

       
        foreach (var plant in _plants)
            plant.UpdateStatus(temp, rain);

        
        var thirsty = _plants
            .Where(p => p.NeedsWater() && p is IIrrigated)
            .Cast<IIrrigated>()
            .ToList();

        if (thirsty.Count == 0)
        {
            _log.Add("No irrigation needed");
        }
        else
        {
            foreach (var p in thirsty)
            {
                p.Irrigate(5.0);
                var plant = p as Plant;
                _log.Add($"Irrigated {plant?.Name} with 5.0 units");
                _irrigatedToday++;
            }
        }
    }

    public string GetStatus()
    {
        var plantLines = _plants.Select(p =>
            $"{p.Name}:" +
            $"{(p.IsAlive ? "Alive" : "Dead")}, " + 
            $"Moisture: {p.SoilMoisture:F1}%, " +
            $"Needs water: {p.NeedsWater()}" 
        );
        _log.Add("Status requested");
        return string.Join("\n", plantLines);
    }

    public string GenerateReport()
    {
        int total = _plants.Count;
        int alive = _plants.Count(p => p.IsAlive);
        int dead = _plants.Count(p => !p.IsAlive);
        double avgMoisture = total > 0 ? _plants.Average(p => p.SoilMoisture) : 0;
        int thirsty = _plants.Count(p => p.NeedsWater());

        return $"""
                
                
                === DAILY REPORT ===
                Total plants: {total}
                Alive: {alive}
                Dead: {dead}
                Average moisture: {avgMoisture:F1}%
                Thirsty plants: {thirsty}
                Irrigated today: {_irrigatedToday}
                """;
    }
}