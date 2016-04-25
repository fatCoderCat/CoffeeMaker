using CoffeeMaker.Hardware;

namespace CoffeeMaker.Components
{
    public class ReadyLamp
    {
        private readonly ILamp _harware;

        public ReadyLamp(ILamp hardware)
        {
            _harware = hardware;
        }

        public void On()
        {
            _harware.SetLampState(DeviceState.On);
        }

        public void Off()
        {
            _harware.SetLampState(DeviceState.Off);
        }
    }
}