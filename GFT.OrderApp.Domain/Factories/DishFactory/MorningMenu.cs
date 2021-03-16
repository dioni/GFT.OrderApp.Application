using GFT.OrderApp.Domain.DishAggregate;
using GFT.OrderApp.Domain.OrderAggregate;

namespace GFT.OrderApp.Domain.Factories.DishFactory
{
    public class MorningMenu : DishFactory, IDishFactory
    {
        public MorningMenu()
        {
            TimeOfDay = TimeOfDay.Morning;
        }
        protected override Dish[] Options
        {
            get
            {
                return new Dish[]
                {
                    new Entree("eggs"),
                    new Side("toast"),
                    new Drink("coffee")
                };
            }
        }
    }
}
