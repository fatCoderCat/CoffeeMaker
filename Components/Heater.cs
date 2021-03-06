﻿using CoffeeMaker.Hardware;

namespace CoffeeMaker.Components
{
    /// <summary>
    /// Heating element. Heat the water in boiler.
    /// </summary>
    public class Heater
    {
        private readonly IHeater _hardware;

        public Heater(IHeater hardware)
        {
            _hardware = hardware;
        }

        public void On()
        {
            _hardware.SetHeaterStatus(DeviceState.On);
        }

        public void Off()
        {
            _hardware.SetHeaterStatus(DeviceState.Off);
        }
    }
}