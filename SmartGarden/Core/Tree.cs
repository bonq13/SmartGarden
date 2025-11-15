namespace SmartGarden;

public class Tree : Plant
{
    public Tree(string name, double optimalTemp):base(name,optimalTemp){}

    public override bool NeedsWater()
    {
        return SoilMoisture < 40;
    }

    public override void UpdateStatus(double temp, double precipitation)
    {
        base.UpdateStatus(temp, precipitation);
        if (temp < -10 || temp > 45)
        {
            IsAlive = false;
        }

        SoilMoisture +=  precipitation * 0.6;
        SoilMoisture = Math.Clamp(SoilMoisture, 0, 100);
    }
}