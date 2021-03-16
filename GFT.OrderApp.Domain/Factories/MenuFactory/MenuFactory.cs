using GFT.OrderApp.Domain.Factories.DishFactory;
using GFT.OrderApp.Domain.OrderAggregate;

namespace GFT.OrderApp.Domain.Factories.MenuFactory
{
    public class MenuFactory : IMenuFactory
    {
        public DishFactory.DishFactory Make(TimeOfDay timeOfDay)
        {
            MenuFactoryValidator.ThatMembers()
                .Validate(timeOfDay)
                .Guard();

            if (timeOfDay.ValueEquals(TimeOfDay.Morning))
                return new MorningMenu();
            else
                return new NightMenu();
        }
    }
}
