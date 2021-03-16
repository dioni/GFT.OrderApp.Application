using GFT.OrderApp.Domain.DishAggregate;

namespace GFT.OrderApp.Domain.Factories.DishFactory
{
    public interface IDishFactory
    {
        Dish Choose(DishType choice);
    }
}
