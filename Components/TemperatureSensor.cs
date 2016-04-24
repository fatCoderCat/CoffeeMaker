using CoffeeMaker.Hardware;

namespace CoffeeMaker
{
    public class TemperatureSensor
    {
        private readonly ITemperatureSensor _hardware;

        public TemperatureSensor(ITemperatureSensor hardware)
        {
            _hardware = hardware;
        }

        public TemperatureStatus GeTemperatureStatus()
        {
            return _hardware.GetSensorStatus();
        }
    }
}