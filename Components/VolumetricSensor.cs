using System;
using CoffeeMaker.Hardware;

namespace CoffeeMaker.Components
{
    public class VolumetricSensor
    {
        private readonly IVolumetricSensor _hardware;

        public VolumetricSensor(IVolumetricSensor hardware)
        {
            _hardware = hardware;
            _hardware.Done += CoffeeIsDone;
        }

        private void CoffeeIsDone(object sender, EventArgs args)
        {
            Done?.Invoke(sender, args);
        }

        public event EventHandler Done;

        public void StartMeasuring(CupSize cupSize)
        {
            _hardware.StartMeasuring((int)cupSize);
        }
    }
}