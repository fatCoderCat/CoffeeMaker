using System;
using CoffeeMaker.Components;
using CoffeeMaker.Hardware;

namespace CoffeeMaker.Controllers
{
    public class MainController
    {
        private readonly CupSizeSelector _cupSizeSelector;
        private readonly Pump _pump;
        private readonly ReadyLamp _readyLamp;
        private readonly VolumetricSensor _volumetricSensor;

        private bool _waterTankIsFull;
        private bool _boilerIsReady;

        internal virtual bool CoffeeMackerIsReady => _waterTankIsFull && _boilerIsReady;
        
        public MainController(ICoffeeMakerApi cofeeMakerApi, IBoilerApi boilerApi)
        {
            var boiler = new BoilerController(boilerApi);
            
            var makeCoffeeButton = new MakeCoffeeButton(cofeeMakerApi);
            var waterSensor = new WaterSensor(cofeeMakerApi);
            _pump = new Pump(cofeeMakerApi);
            _cupSizeSelector = new CupSizeSelector(cofeeMakerApi);
            _volumetricSensor = new VolumetricSensor(cofeeMakerApi);
            _readyLamp = new ReadyLamp(cofeeMakerApi);

            _boilerIsReady = boiler.BoilerIsReady;
            _waterTankIsFull = waterSensor.IsWaterTankFull();

            _volumetricSensor.Done += StopPourCoffee;
            makeCoffeeButton.ButtonPressed += StartPourCoffee;
            waterSensor.WaterTaankStatusChanged += OnWaterSensorWaterTaankStatusChanged;
            boiler.BoilerStatusChanged += OnBoilerStatusChanged;

            CheckReadyLamp();
        }
        
        public void StartPourCoffee(object sender, EventArgs e)
        {
            if (!CoffeeMackerIsReady)
                return;

            var cupSize = _cupSizeSelector.GetCupSize();

            _volumetricSensor.StartMeasuring(cupSize);
            _pump.Start();
        }

        public void StopPourCoffee(object sender, EventArgs e)
        {
            _pump.Stop();
        }

        public void OnBoilerStatusChanged(object sender, BoilerStatusEventArgs args)
        {
            _boilerIsReady = args.BoilerIsReady;
            CheckReadyLamp();
        }

        public void OnWaterSensorWaterTaankStatusChanged(object sender, WaterSensorEventArgs args)
        {
            _waterTankIsFull = args.IsWaterTankFull;

            if (!_waterTankIsFull)
                StopPourCoffee(null, null);

            CheckReadyLamp();
        }

        public void CheckReadyLamp()
        {
            if (CoffeeMackerIsReady)
                _readyLamp.On();
            else
                _readyLamp.Off();
        }
    }
}