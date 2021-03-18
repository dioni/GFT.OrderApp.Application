namespace GFT.OrderApp.Domain.DishAggregate
{
    public class InvalidDish : Dish
    {
        public InvalidDish() : base("error", DishType.Invalid)
        {
        }
    }
}
