using GFT.OrderApp.Domain.Factories.MenuFactory;
using GFT.OrderApp.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace GFT.OrderApp.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton<IOrderService, OrderService>()
                .AddSingleton<IMenuFactory, MenuFactory>()
                .BuildServiceProvider();


            var order = serviceProvider.GetService<IOrderService>();
            order.CreateOrder("morning, 1, 2, 3");
        }
    }
}
