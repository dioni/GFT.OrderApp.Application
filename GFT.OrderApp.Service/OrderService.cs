using GFT.OrderApp.Domain.Factories.MenuFactory;
using GFT.OrderApp.Domain.OrderAggregate;
using System;
using System.Linq;

namespace GFT.OrderApp.Service
{
    public class OrderService : IOrderService
    {
        private readonly IMenuFactory _menuFactory;

        public OrderService(IMenuFactory menuFactory)
        {
            _menuFactory = menuFactory;
        }

        public string CreateOrder(string input)
        {
            var selectedOptions = input.Split(",");

            var timeOfDay = new TimeOfDay(selectedOptions.First());

            var menu = _menuFactory.Make(timeOfDay);

            var order = new Order(timeOfDay);

            foreach (var item in selectedOptions.Skip(1))
            {
                order.AddDish(menu.Choose(Convert.ToInt16(item)));
            }

            order.Close();            

            return order.GenerateOutput();
        }
    }
}
