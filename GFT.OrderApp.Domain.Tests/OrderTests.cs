﻿using GFT.OrderApp.Domain.DishAggregate;
using GFT.OrderApp.Domain.Factories.DishFactory;
using GFT.OrderApp.Domain.OrderAggregate;
using GFT.OrderApp.Infrastructure.Exceptions;
using NUnit.Framework;
using System.Collections.Generic;

namespace GFT.OrderApp.Domain.Tests
{
    [TestFixture]
    public class OrderTests
    {
        private MorningMenu MorningMenu;
        private NightMenu NightMenu;

        [SetUp]
        public void Setup()
        {
            MorningMenu = new MorningMenu();
            NightMenu = new NightMenu();
        }

        [Test]
        public void Throw_exception_when_not_pass_a_time_of_day()
        {
            Assert.Throws<GFTValidationException>(() =>
            {
                new Order(null);
            });
        }

        [Test]
        public void The_time_of_day_must_be_not_null_when_pass_a_time_of_day()
        {
            var order = new Order(TimeOfDay.Morning);

            Assert.AreEqual(TimeOfDay.Morning, order.TimeOfDay);
        }

        [Test]
        public void Can_be_order_more_than_one_coffee_in_the_morning()
        {
            var dishes = new List<Dish>()
            {
                MorningMenu.Choose(DishType.Drink),
                MorningMenu.Choose(DishType.Drink)
            };

            var validator = new OrderValidator();
            validator.ValidateDishesCount(dishes, TimeOfDay.Morning).Guard();
            Assert.Pass();
        }

        [Test]
        public void Can_be_order_more_than_one_potatoes_in_the_night()
        {
            var dishes = new List<Dish>()
            {
                NightMenu.Choose(DishType.Side),
                NightMenu.Choose(DishType.Side)
            };

            var validator = new OrderValidator();
            validator.ValidateDishesCount(dishes, TimeOfDay.Night).Guard();
            Assert.Pass();
        }

        [Test]
        public void Throw_exception_when_more_than_once_entree()
        {
            var dishes = new List<Dish>()
            {
                NightMenu.Choose(DishType.Entree),
                NightMenu.Choose(DishType.Entree)
            };

            var validator = new OrderValidator();
            Assert.Throws<GFTValidationException>(() =>
            {
                validator.ValidateDishesCount(dishes, TimeOfDay.Night).Guard();
            });
        }

        [Test]
        public void Throw_exception_when_more_than_once_drink_on_night()
        {
            var dishes = new List<Dish>()
            {
                NightMenu.Choose(DishType.Drink),
                NightMenu.Choose(DishType.Drink)
            };

            var validator = new OrderValidator();
            Assert.Throws<GFTValidationException>(() =>
            {
                validator.ValidateDishesCount(dishes, TimeOfDay.Night).Guard();
            });
        }

        [Test]
        public void Throw_exception_when_more_than_once_side_on_morning()
        {
            var dishes = new List<Dish>()
            {
                MorningMenu.Choose(DishType.Side),
                MorningMenu.Choose(DishType.Side)
            };

            var validator = new OrderValidator();
            Assert.Throws<GFTValidationException>(() =>
            {
                validator.ValidateDishesCount(dishes, TimeOfDay.Morning).Guard();
            });
        }

        [Test]
        public void Must_return_eggs_toast_coffee()
        {
            var order = new Order(TimeOfDay.Morning);
            order.AddDish(MorningMenu.Choose(DishType.Entree));
            order.AddDish(MorningMenu.Choose(DishType.Side));
            order.AddDish(MorningMenu.Choose(DishType.Drink));

            Assert.AreEqual("eggs, toast, coffee", order.GenerateOutput());
        }

        [Test]
        public void Must_return_eggs_toast_coffee_too()
        {
            var order = new Order(TimeOfDay.Morning);
            order.AddDish(MorningMenu.Choose(DishType.Side));
            order.AddDish(MorningMenu.Choose(DishType.Entree));
            order.AddDish(MorningMenu.Choose(DishType.Drink));

            Assert.AreEqual("eggs, toast, coffee", order.GenerateOutput());
        }

        [Test]
        public void Must_return_eggs_toast_coffee_error()
        {
            var order = new Order(TimeOfDay.Morning);
            order.AddDish(MorningMenu.Choose(DishType.Entree));
            order.AddDish(MorningMenu.Choose(DishType.Side));
            order.AddDish(MorningMenu.Choose(DishType.Drink));
            order.AddDish(MorningMenu.Choose(DishType.Dessert));

            Assert.AreEqual("eggs, toast, coffee, error", order.GenerateOutput());
        }

        [Test]
        public void Must_return_eggs_toast_coffee_x_3()
        {
            var order = new Order(TimeOfDay.Morning);
            order.AddDish(MorningMenu.Choose(DishType.Entree));
            order.AddDish(MorningMenu.Choose(DishType.Side));
            order.AddDish(MorningMenu.Choose(DishType.Drink));
            order.AddDish(MorningMenu.Choose(DishType.Drink));
            order.AddDish(MorningMenu.Choose(DishType.Drink));            

            Assert.AreEqual("eggs, toast, coffee(x3)", order.GenerateOutput());
        }

        [Test]
        public void Must_return_steak_potato_wine_cake()
        {
            var order = new Order(TimeOfDay.Night);
            order.AddDish(NightMenu.Choose(DishType.Entree));
            order.AddDish(NightMenu.Choose(DishType.Side));
            order.AddDish(NightMenu.Choose(DishType.Drink));
            order.AddDish(NightMenu.Choose(DishType.Dessert));

            Assert.AreEqual("steak, potato, wine, cake", order.GenerateOutput());
        }

        [Test]
        public void Must_return_steak_potato_x2_cake()
        {
            var order = new Order(TimeOfDay.Night);
            order.AddDish(NightMenu.Choose(DishType.Entree));
            order.AddDish(NightMenu.Choose(DishType.Side));
            order.AddDish(NightMenu.Choose(DishType.Side));
            order.AddDish(NightMenu.Choose(DishType.Dessert));

            Assert.AreEqual("steak, potato(x2), cake", order.GenerateOutput());
        }

        [Test]
        public void Must_return_steak_potato_wine_error()
        {
            var order = new Order(TimeOfDay.Night);
            order.AddDish(NightMenu.Choose(DishType.Entree));
            order.AddDish(NightMenu.Choose(DishType.Side));
            order.AddDish(NightMenu.Choose(DishType.Drink));
            order.AddDish(NightMenu.Choose(5));

            Assert.AreEqual("steak, potato, wine, error", order.GenerateOutput());
        }
    }
}
