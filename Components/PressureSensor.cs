using System;
using CoffeeMaker.Hardware;

namespace CoffeeMaker.Components
{
    public class PressureSensor
    {
        private readonly IPressureSensor _hardware;

        public PressureSensor(IPressureSensor hardware)
        {
            _hardware = hardware;
            _hardware.PressureChanged += OnPressureChanged;
        }

        private void OnPressureChanged(object sender, PressureStatusEventArgs args)
        {
            PressureChanged?.Invoke(sender, args);
        }

        public EventHandler<PressureStatusEventArgs> PressureChanged;
    }
}
