namespace GFT.OrderApp.Domain.DishAggregate
{
    public class Side : Dish
    {
        public Side(string name) : base(name, DishType.Side)
        {
        }
    }
}
