using CoffeeMaker.Hardware;

namespace CoffeeMaker.Components
{
    public class SteamValve
    {
        private readonly ISteamValve _hardware;

        public SteamValve(ISteamValve hardware)
        {
            _hardware = hardware;
        }

        public void On()
        {
            _hardware.SetSteamValveState(DeviceState.On);
        }

        public void Off()
        {
            _hardware.SetSteamValveState(DeviceState.Off);
        }
    }
}