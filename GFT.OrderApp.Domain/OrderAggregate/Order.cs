using GFT.OrderApp.Domain.DishAggregate;
using System.Collections.Generic;
using System.Linq;

namespace GFT.OrderApp.Domain.OrderAggregate
{
    public class Order
    {
        public List<Dish> Dishes { get; private set; }
        public TimeOfDay TimeOfDay { get; private set; }

        public Order(TimeOfDay timeOfDay)
        {
            OrderValidator.ThatMembers()
                .ValidateTimeOfDay(timeOfDay)
                .Guard();

            TimeOfDay = timeOfDay;
            Dishes = new List<Dish>();
        }

        public void AddDish(Dish dish)
        {
            Dishes.Add(dish);
        }

        public void Close()
        {
            OrderValidator.ThatMembers()
                .ValidateAtLeastOneSelection(Dishes.Count)
                .ValidateDishesCount(Dishes, TimeOfDay)
                .Guard();
        }

        public string GenerateOutput()
        {
            var dishNames = new List<string>();

            var dishesByType = Dishes.OrderBy(x => x.DishType.Code).GroupBy(x => x.DishType).Select(x => new { Type = x.Key, Count = x.Count() });

            foreach (var dishByType in dishesByType)
            {
                var dishName = Dishes.First(x => x.DishType == dishByType.Type).Name;

                if (dishByType.Count > 1)
                {
                    dishName = $"{dishName}(x{dishByType.Count})";
                }

                dishNames.Add(dishName);
            }

            return string.Join(", ", dishNames);
        }
    }
}
