namespace SmartGarden;

public interface ISensor<T>
{
    T TakeMeasurement();
}