using System;

namespace CoffeeMaker.Hardware
{
    public interface IButton
    {
        event EventHandler ButtonPressed;
    }
}