using System;

namespace CoffeeMaker
{
    public class PressureStatusEventArgs : EventArgs
    {
        public PressureStatus PressureStatus { get; set; }
    }
}