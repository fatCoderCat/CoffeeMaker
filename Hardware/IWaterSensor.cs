namespace CoffeeMaker.Hardware
{
    internal interface IWaterSensor
    {
        PressureStatus GetSensorStatus();
    }
}