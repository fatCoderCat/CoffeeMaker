namespace CoffeeMaker.Hardware
{
    public interface ICoffeeMakerApi : IButton, IPump, ICupSizeSelector, IVolumetricSensor, IWaterSensor, ILamp
    {
    }
}