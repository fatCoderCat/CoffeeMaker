namespace CoffeeMaker.Hardware
{
    public class Pump
    {
        private readonly IPump _hardware;

        public Pump(IPump hardware)
        {
            _hardware = hardware;
        }

        public void Start()
        {
            _hardware.SetPumpState(DeviceState.On);
        }

        public void Stop()
        {
            _hardware.SetPumpState(DeviceState.Off);
        }
    }
}