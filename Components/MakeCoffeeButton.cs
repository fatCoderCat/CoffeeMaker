﻿using System;
using CoffeeMaker.Hardware;

namespace CoffeeMaker.Components
{
    /// <summary>
    /// Button launch coffee brewing process.
    /// </summary>
    public class MakeCoffeeButton
    {
        private readonly IButton _hardware;

        public MakeCoffeeButton(IButton hardware)
        {
            _hardware = hardware;
            _hardware.ButtonPressed += OnButtonPress;
        }

        private void OnButtonPress(object sender, EventArgs args)
        {
            ButtonPressed?.Invoke(sender, args);
        }

        public event EventHandler ButtonPressed;
    }
}
