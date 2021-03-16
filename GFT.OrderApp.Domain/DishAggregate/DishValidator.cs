using GFT.OrderApp.Infrastructure.Validations;

namespace GFT.OrderApp.Domain.DishAggregate
{
    public class DishValidator : Validates
    {
        public static DishValidator ThatMembers() => new DishValidator();

        public Validates Validate(string name, DishType dishType)
        {   
            Compute(!string.IsNullOrWhiteSpace(name), name, "Name is required", nameof(Dish.Name));

            Compute(dishType != null, name, "DishType is required", nameof(Dish.DishType));

            return this;
        }
    }
}
