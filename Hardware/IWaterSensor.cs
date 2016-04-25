using System;

namespace CoffeeMaker.Hardware
{
    public interface IWaterSensor
    {
        DeviceState GetWaterSensorStatus();
        event EventHandler<WaterSensorEventArgs> WaterTankStatusChanged;
    }
}