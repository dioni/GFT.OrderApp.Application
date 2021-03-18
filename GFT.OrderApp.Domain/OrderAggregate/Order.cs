using GFT.OrderApp.Domain.Base;
using GFT.OrderApp.Domain.DishAggregate;
using GFT.OrderApp.Domain.Exceptions;
using GFT.OrderApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GFT.OrderApp.Domain.OrderAggregate
{
    public class Order : Entity
    {
        public List<Dish> Dishes { get; private set; }
        public TimeOfDay TimeOfDay { get; private set; }

        public Order(TimeOfDay timeOfDay)
        {
            TimeOfDay = timeOfDay ?? throw new OrderAppDomainException("TimeOfDay is required");
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

                if (dishName == "error")
                {
                    break;
                }
            }

            return string.Join(", ", dishNames);
        }
    }
}
