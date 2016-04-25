using System;
using CoffeeMaker.Hardware;

namespace CoffeeMaker.Components
{
    public class WaterSensor
    {
        private readonly IWaterSensor _hardware;

        public WaterSensor(IWaterSensor hardware)
        {
            _hardware = hardware;
            _hardware.WaterTankStatusChanged += OnWaterTankStatusChanged;
        }
        
        public bool IsWaterTankFull()
        {
            return _hardware.GetWaterSensorStatus() == DeviceState.On;
        }

        private void OnWaterTankStatusChanged(object sender, WaterSensorEventArgs args)
        {
            WaterTaankStatusChanged?.Invoke(sender, args);
        }

        public event EventHandler<WaterSensorEventArgs> WaterTaankStatusChanged;
    }
}