namespace GFT.OrderApp.Domain.DishAggregate
{
    public abstract class Dish
    {
        public string Name { get; private set; }
        public DishType DishType { get; private set; }

        public Dish(string name, DishType dishType)
        {
            DishValidator.ThatMembers()
                .Validate(name, dishType)
                .Guard();

            Name = name;
            DishType = dishType;
        }
    }
}
