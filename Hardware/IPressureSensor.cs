using System;

namespace CoffeeMaker.Hardware
{
    public interface IPressureSensor
    {
        event EventHandler<PressureStatusEventArgs> PressureChanged;
    }
}