using GFT.OrderApp.Domain.DishAggregate;
using GFT.OrderApp.Infrastructure.Validations;
using System.Collections.Generic;
using System.Linq;

namespace GFT.OrderApp.Domain.OrderAggregate
{
    public class OrderValidator : Validates
    {
        public static OrderValidator ThatMembers() => new OrderValidator();

        public OrderValidator ValidateTimeOfDay(TimeOfDay timeOfDay)
        {
            Compute(timeOfDay != null, timeOfDay, "TimeOfDay is required", nameof(Order.TimeOfDay));

            return this;
        }


        public OrderValidator ValidateAtLeastOneSelection(int count)
        {
            var success = count > 0;
            
            Compute(success, count, "You must select at least one dish", nameof(Order.Dishes));

            return this;
        }

        public Validates ValidateDishesCount(IList<Dish> dishes, TimeOfDay timeOfDay)
        {
            var dishesByType = dishes.GroupBy(x => x.DishType).Select(x => new { Type = x.Key, Count = x.Count() });

            foreach (var dishByType in dishesByType)
            {
                if (dishByType.Count > 1)
                {
                    if (!IsCoffeeOnMorning(timeOfDay, dishByType.Type) && !IsPotatoesOnNight(timeOfDay, dishByType.Type))
                    {
                        Compute(false, dishes, "You can only order 1 of each dish type with the exception of coffee in the morning or potatoes in the night", nameof(Order.Dishes));
                    }
                }
            }

            return this;
        }

        private bool IsCoffeeOnMorning(TimeOfDay timeOfDay, DishType dishType)
        {
            return timeOfDay.ValueEquals(TimeOfDay.Morning) && dishType.ValueEquals(DishType.Drink);
        }

        private bool IsPotatoesOnNight(TimeOfDay timeOfDay, DishType dishType)
        {
            return timeOfDay.ValueEquals(TimeOfDay.Night) && dishType.ValueEquals(DishType.Side);
        }
    }
}
