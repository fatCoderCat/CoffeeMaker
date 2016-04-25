using CoffeeMaker.Components;

namespace CoffeeMaker.Hardware
{
    public interface ICupSizeSelector
    {
        CupSize GetCupSize();
    }
}