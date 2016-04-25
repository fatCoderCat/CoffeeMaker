using System;

namespace CoffeeMaker.Hardware
{
    public interface ITemperatureSensor
    {
        event EventHandler<TemperatureStatusEventArgs> TemperatureIsChanged; 
    }
}