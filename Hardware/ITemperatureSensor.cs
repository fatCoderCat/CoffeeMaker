namespace CoffeeMaker.Hardware
{
    public interface ITemperatureSensor
    {
        TemperatureStatus GetSensorStatus();
    }
}