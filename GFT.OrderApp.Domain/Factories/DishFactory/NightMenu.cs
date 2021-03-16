using GFT.OrderApp.Domain.DishAggregate;
using GFT.OrderApp.Domain.OrderAggregate;

namespace GFT.OrderApp.Domain.Factories.DishFactory
{
    public class NightMenu : DishFactory
    {
        public NightMenu()
        {
            TimeOfDay = TimeOfDay.Night;
        }

        protected override Dish[] Options
        {
            get
            {
                return new Dish[]
                {
                    new Entree("steak"),
                    new Side("potato"),
                    new Drink("wine"),
                    new Dessert("cake")
                };
            }
        }
    }
}
