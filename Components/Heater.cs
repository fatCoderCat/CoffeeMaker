using CoffeeMaker.Hardware;

namespace CoffeeMaker
{
    public class Heater
    {
        private IHeater _hardware;

        public Heater(IHeater hardware)
        {
            _hardware = hardware;
        }

        public void On()
        {
            _hardware.SetStatus(DeviceState.On);
        }

        public void Off()
        {
            _hardware.SetStatus(DeviceState.Off);
        }
    }
}