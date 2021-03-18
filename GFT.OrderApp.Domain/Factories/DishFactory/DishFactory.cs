using GFT.OrderApp.Domain.DishAggregate;
using GFT.OrderApp.Domain.OrderAggregate;
using System.Linq;

namespace GFT.OrderApp.Domain.Factories.DishFactory
{
    public abstract class DishFactory : IDishFactory
    {
        protected TimeOfDay TimeOfDay { get; set; }
        protected abstract Dish[] Options { get; }
        public Dish Choose(DishType choice)
        {
            if (choice.ValueEquals(DishType.Invalid) || (TimeOfDay.ValueEquals(TimeOfDay.Morning) && choice.ValueEquals(DishType.Dessert)))
            {
                return new InvalidDish();
            }

            return Options.Single(x => x.DishType == choice);
        }
    }
}
