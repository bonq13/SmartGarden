namespace SmartGarden;

public class Flower : Plant, IIrrigated
{
    public Flower(string name, double optimalTemp)
        : base(name, optimalTemp)
    {}
    

    public override bool NeedsWater()
    {
        return SoilMoisture < 60;
    }

    public void Irrigate(double waterAmount)
    {
        SoilMoisture = Math.Min(100, (SoilMoisture + waterAmount) * 0.8);
    }

    public override void UpdateStatus(double temp, double precipitation)
    {
        base.UpdateStatus(temp, precipitation);
        if (temp > 35)
        {
            IsAlive = false;
        }

        SoilMoisture += precipitation * 1.2;
        SoilMoisture = Math.Clamp(SoilMoisture, 0, 100);
    }
}