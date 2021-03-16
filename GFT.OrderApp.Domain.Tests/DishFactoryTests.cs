using GFT.OrderApp.Domain.DishAggregate;
using GFT.OrderApp.Domain.Factories.DishFactory;
using GFT.OrderApp.Infrastructure.Exceptions;
using NUnit.Framework;

namespace GFT.OrderApp.Domain.Tests
{
    [TestFixture]
    public class DishFactoryTests
    {
        [Test]
        public void Throw_exception_when_order_a_dessert_on_morning()
        {
            Assert.Throws<GFTValidationException>(() =>
            {
                new MorningMenu().Choose(DishType.Dessert);
            });
        }

        [Test]
        public void Must_create_a_eggs_when_morning_entree()
        {
            var dish = new MorningMenu().Choose(DishType.Entree);

            Assert.AreEqual("eggs", dish.Name);
        }

        [Test]
        public void Must_create_a_toast_when_morning_side()
        {
            var dish = new MorningMenu().Choose(DishType.Side);

            Assert.AreEqual("toast", dish.Name);
        }

        [Test]
        public void Must_create_a_coffee_when_morning_drink()
        {
            var dish = new MorningMenu().Choose(DishType.Drink);

            Assert.AreEqual("coffee", dish.Name);
        }

        [Test]
        public void Must_create_a_steak_when_night_entree()
        {
            var dish = new NightMenu().Choose(DishType.Entree);

            Assert.AreEqual("steak", dish.Name);
        }

        [Test]
        public void Must_create_a_potato_when_night_side()
        {
            var dish = new NightMenu().Choose(DishType.Side);

            Assert.AreEqual("potato", dish.Name);
        }

        [Test]
        public void Must_create_a_wine_when_night_drink()
        {
            var dish = new NightMenu().Choose(DishType.Drink);

            Assert.AreEqual("wine", dish.Name);
        }

        [Test]
        public void Must_create_a_cake_when_night_dessert()
        {
            var dish = new NightMenu().Choose(DishType.Dessert);

            Assert.AreEqual("cake", dish.Name);
        }
    }
}
