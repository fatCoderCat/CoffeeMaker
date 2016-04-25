using CoffeeMaker.Hardware;

namespace CoffeeMaker.Components
{
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