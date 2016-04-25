using System;

namespace CoffeeMaker
{
    public class TemperatureStatusEventArgs : EventArgs
    {
        public TemperatureStatus TemperatureStatus { get; set; }
    }
}