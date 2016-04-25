using System;
using CoffeeMaker.Hardware;

namespace CoffeeMaker.Components
{
    public class TemperatureSensor
    {
        private readonly ITemperatureSensor _hardware;

        public TemperatureSensor(ITemperatureSensor hardware)
        {
            _hardware = hardware;
            _hardware.TemperatureIsChanged += OnTemperatureChanged;
        }

        private void OnTemperatureChanged(object sender, TemperatureStatusEventArgs args)
        {
            TemperatureIsChanged?.Invoke(sender, args);
        }

        public event EventHandler<TemperatureStatusEventArgs> TemperatureIsChanged;
    }
}