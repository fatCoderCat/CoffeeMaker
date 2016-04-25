using System;

namespace CoffeeMaker
{
    public class WaterSensorEventArgs : EventArgs
    {
        public bool IsWaterTankFull { get; set; }
    }
}