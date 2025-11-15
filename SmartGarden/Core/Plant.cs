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
    }
    
    public abstract bool NeedsWater();

    public virtual void UpdateStatus(double temp, double precipitation)
    {
        
    }
}