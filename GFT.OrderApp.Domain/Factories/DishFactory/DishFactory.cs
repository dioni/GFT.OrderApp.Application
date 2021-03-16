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
            DishFactoryValidator.ThatMembers()
                .ValidateChoice(choice, TimeOfDay)
                .Guard();

            return Options.Single(x => x.DishType == choice);
        }
    }
}
