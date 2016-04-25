using System;

namespace CoffeeMaker.Hardware
{
    public interface IVolumetricSensor
    {
        void StartMeasuring(int volume);
        event EventHandler Done;
    }
}