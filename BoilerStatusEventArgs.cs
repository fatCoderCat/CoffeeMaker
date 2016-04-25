using System;

namespace CoffeeMaker
{
    public class BoilerStatusEventArgs : EventArgs
    {
        public bool BoilerIsReady { get; set; }
    }
}