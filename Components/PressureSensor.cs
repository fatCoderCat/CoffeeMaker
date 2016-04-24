using CoffeeMaker.Hardware;

namespace CoffeeMaker.Components
{
    public class PressureSensor
    {
        private readonly IPressureSensor _hardware;

        public PressureSensor(IPressureSensor hardware)
        {
            _hardware = hardware;
        }

        public PressureStatus GetStatus()
        {
            return _hardware.GetPressureSensorStatus();
        }
    }
}
