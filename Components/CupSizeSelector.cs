using CoffeeMaker.Hardware;

namespace CoffeeMaker.Components
{
    /// <summary>
    /// Allows to chose cup size.
    /// </summary>
    public class CupSizeSelector
    {
        private readonly ICupSizeSelector _hardware;

        public CupSizeSelector(ICupSizeSelector hardware)
        {
            _hardware = hardware;
        }

        public CupSize GetCupSize()
        {
            return _hardware.GetCupSize();
        }
    }
}