using System;
using CoffeeMaker.Components;
using CoffeeMaker.Hardware;

namespace CoffeeMaker.Controllers
{
    /// <summary>
    /// Controlls boiling and steam generation processes.
    /// </summary>
    public class BoilerController
    {
        private readonly Heater _heater;
        private readonly SteamValve _steamValve;
        private readonly PressureSensor _pressureSensor;
        private readonly TemperatureSensor _temperatureSensor;

        private bool _boilerIsReady;
        
        public BoilerController(IBoilerApi hardwareApi)
        {
            _heater = new Heater(hardwareApi);
            _steamValve = new SteamValve(hardwareApi);
            _pressureSensor = new PressureSensor(hardwareApi);
            _temperatureSensor = new TemperatureSensor(hardwareApi);
            
            _pressureSensor.PressureChanged += NormalizePressure;
            _temperatureSensor.TemperatureIsChanged += NormalizeTemperature;

            Init();
        }


        /// <summary>
        /// Indicates wheather boiler is ready to brew.
        /// </summary>
        public bool BoilerIsReady
        {
            get
            {
                return _boilerIsReady;
            }
            private set
            {
                if (value != _boilerIsReady)
                {
                    _boilerIsReady = value;
                    BoilerStatusChanged?.Invoke(this, new BoilerStatusEventArgs { BoilerIsReady = _boilerIsReady });
                }
            }
        }

        public event EventHandler<BoilerStatusEventArgs> BoilerStatusChanged;

        /// <summary>
        /// Set initial state of hardware.
        /// </summary>
        private void Init()
        {
            _heater.On();
            _steamValve.Off();
            _boilerIsReady = false;
        }
        
        /// <summary>
        /// Hold the pressure in boiler.
        /// </summary>
        private void NormalizePressure(object x, PressureStatusEventArgs args)
        {
            if (args.PressureStatus == PressureStatus.Warn)
                _steamValve.On();
            else if (args.PressureStatus == PressureStatus.Ok)
                _steamValve.Off();
        }

        /// <summary>
        /// Hold the temperature in boiler.
        /// </summary>
        private void NormalizeTemperature(object x, TemperatureStatusEventArgs args)
        {
            if (args.TemperatureStatus == TemperatureStatus.Low)
            {
                _heater.On();
                BoilerIsReady = false;
            }
            else if (args.TemperatureStatus == TemperatureStatus.High)
            {
                _heater.Off();
                BoilerIsReady = true;
            }
            else if (args.TemperatureStatus == TemperatureStatus.Normal)
            {
                BoilerIsReady = true;
            }
        }
    }
}