namespace GFT.OrderApp.Domain.DishAggregate
{
    public class Drink : Dish
    {
        public Drink(string name) : base(name, DishType.Drink)
        {
        }
    }
}
