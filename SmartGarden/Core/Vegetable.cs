namespace SmartGarden;

public class Vegetable : Plant, IIrrigated
{
    public Vegetable(string name, double optimalTemp) : base(name, optimalTemp){}

    public override bool NeedsWater()
    {
        return SoilMoisture < 70;
    }

    public void Irrigate(double waterAmount)
    {
        SoilMoisture = Math.Min(100, SoilMoisture + waterAmount);
    }

    public override void UpdateStatus(double temp, double precipitation)
    {
        base.UpdateStatus(temp, precipitation);

        if (temp < 4 || temp > 32)
        {
            IsAlive = false;
        }
        SoilMoisture += precipitation * 0.9;
        SoilMoisture = Math.Clamp(SoilMoisture, 0, 100);
    }
}