namespace SmartGarden;

public class WeatherService : IWeather
{
    private readonly Random _rand = new ();

    public double GetTemperature()
    {
        return 15 + _rand.NextDouble() * 20;
    }

    public double GetPrecipitation()
    {
        return _rand.NextDouble() > 0.7 ? _rand.NextDouble() * 10 : 0;
    }
}