using GFT.OrderApp.Domain.DishAggregate;
using GFT.OrderApp.Domain.OrderAggregate;
using GFT.OrderApp.Infrastructure.Validations;

namespace GFT.OrderApp.Domain.Factories.DishFactory
{
    public class DishFactoryValidator : Validates
    {
        public static DishFactoryValidator ThatMembers() => new DishFactoryValidator();

        public Validates ValidateChoice(DishType choice, TimeOfDay timeOfDay)
        {
            var success = !(choice.ValueEquals(DishType.Dessert) && timeOfDay.ValueEquals(TimeOfDay.Morning));
            return Compute(success, choice, "There is no dessert for morning meals", nameof(Dish.DishType));
        }
    }
}
