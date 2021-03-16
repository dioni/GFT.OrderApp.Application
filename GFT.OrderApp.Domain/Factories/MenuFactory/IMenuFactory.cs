using GFT.OrderApp.Domain.Factories.DishFactory;
using GFT.OrderApp.Domain.OrderAggregate;

namespace GFT.OrderApp.Domain.Factories.MenuFactory
{
    public interface IMenuFactory
    {
        DishFactory.DishFactory Make(TimeOfDay timeOfDay);
    }
}
