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
    public class Order: Entity
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
            //1.You must enter time of day as “morning” or “night”  ok
            //2.You must enter a comma delimited list of dish types with at least one selection  ok
            //3.The output must print food in the following order: entrée, side, drink, dessert ok
            //4.There is no dessert for morning meals ok
            //5.Input is not case sensitive ok
            //6.If invalid selection is encountered, display valid selections up to the error, then print error ok
            //7.In the morning, you can order multiple cups of coffee
            //8.At night, you can have multiple orders of potatoes
            //9.Except for the above rules, you can only order 1 of each dish type

            Dishes.Add(dish);
        }

        public void Close()
        {
            OrderValidator.ThatMembers()
                .ValidateAtLeastOneSelection(Dishes.Count)
                .ValidateDishesCount(Dishes, TimeOfDay)
                .Guard();
        }

        public override string ToString()
        {
            return string.Join(", ", Dishes.OrderBy(x => x.DishType.Code).Select(x => x.Name));
        }
    }
}
