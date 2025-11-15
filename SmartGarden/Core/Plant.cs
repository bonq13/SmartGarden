namespace SmartGarden;

public abstract class Plant
{
    public string Name { get; init; }
    public double SoilMoisture { get; protected set; }
    public double OptimalTemperature { get; init; }
    public bool IsAlive { get; protected set; } = true;

    protected Plant(string name, double optimalTemp)
    {
        Name = name;
        OptimalTemperature = optimalTemp;
        SoilMoisture = 50 + Random.Shared.NextDouble() * 30;
    }
    
    public abstract bool NeedsWater();

    public virtual void UpdateStatus(double temp, double precipitation)
    {
        if (temp < 0 || temp > 40)
        {
            IsAlive = false;
            return;
        }
        
        SoilMoisture += precipitation * 0.8;

        
        SoilMoisture -= 2.0 + temp * 0.1; 

        
        SoilMoisture = Math.Clamp(SoilMoisture, 0, 100);
    }
}