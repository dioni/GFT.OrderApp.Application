using GFT.OrderApp.Domain.OrderAggregate;
using GFT.OrderApp.Infrastructure.Validations;

namespace GFT.OrderApp.Domain.Factories.DishFactory
{
    public class MenuFactoryValidator : Validates
    {
        public static MenuFactoryValidator ThatMembers() => new MenuFactoryValidator();

        public Validates Validate(TimeOfDay timeOfDay)
        {
            return Compute(timeOfDay != null, timeOfDay, "TimeOfDay is required", nameof(TimeOfDay.Name));
        }
    }
}
