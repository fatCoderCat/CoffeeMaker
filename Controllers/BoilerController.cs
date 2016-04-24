using System.Threading;
using CoffeeMaker.Components;
using CoffeeMaker.Hardware;

namespace CoffeeMaker.Controllers
{
    internal class BoilerController
    {
        private Timer _timer;
        private readonly Heater _heater;
        private readonly SteamValve _steamValve;
        private readonly PressureSensor _pressureSensor;
        private readonly TemperatureSensor _temperatureSensor;

        private bool _steamValveIsOn;
        private bool _heaterIsOn;

        public BoilerController(IBoilerApi hardwareApi)
        {
            _heater = new Heater(hardwareApi);
            _steamValve = new SteamValve(hardwareApi);
            _pressureSensor = new PressureSensor(hardwareApi);
            _temperatureSensor = new TemperatureSensor(hardwareApi);
            _timer = new Timer(TimerElapsed, null, 0, 1000);
        }

        private void TimerElapsed(object o)
        {
            NormalizePressure();
            NormalizeTemperature();
        }
        //add possibility to make steam and add light
        //add

        private void NormalizePressure()
        {
            var pressureStatus = _pressureSensor.GetStatus();
            if (pressureStatus == PressureStatus.Warn && !_steamValveIsOn)
            {
                _steamValve.On();
                _steamValveIsOn = true;
            }
            else if (pressureStatus == PressureStatus.Ok && _steamValveIsOn)
            {
                _steamValve.Off();
                _steamValveIsOn = false;
            }
        }

        private void NormalizeTemperature()
        {
            var temperatureStatus = _temperatureSensor.GeTemperatureStatus();
            if (temperatureStatus == TemperatureStatus.Low && !_heaterIsOn)
            {
                _heater.On();
                _heaterIsOn = true;
            }
            else if (temperatureStatus == TemperatureStatus.High && _heaterIsOn)
            {
                _heater.Off();
                _heaterIsOn = false;
            }
        }
    }
}