namespace SmartGarden;

public class SoilMoistureSensor : ISensor<double>
{
    private readonly Random _rand = new ();

    public double TakeMeasurement()
    {
        return 20 + _rand.NextDouble() * 70;
    }
}