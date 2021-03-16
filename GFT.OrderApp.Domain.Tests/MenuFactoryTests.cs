using GFT.OrderApp.Domain.Factories.DishFactory;
using GFT.OrderApp.Domain.Factories.MenuFactory;
using GFT.OrderApp.Domain.OrderAggregate;
using GFT.OrderApp.Infrastructure.Exceptions;
using NUnit.Framework;

namespace GFT.OrderApp.Domain.Tests
{
    [TestFixture]
    public class MenuFactoryTests
    {
        [Test]
        public void Throw_exception_when_not_pass_a_time_of_day()
        {
            Assert.Throws<GFTValidationException>(() =>
            {
                new MenuFactory().Make(null);
            });
        }

        [Test]
        public void Must_create_a_morning_menu_when_pass_morning_time()
        {
            var menu = new MenuFactory().Make(TimeOfDay.Morning);

            Assert.True(menu is MorningMenu);
        }

        [Test]
        public void Must_create_a_night_menu_when_pass_night_time()
        {
            var menu = new MenuFactory().Make(TimeOfDay.Night);

            Assert.True(menu is NightMenu);
        }
    }
}
