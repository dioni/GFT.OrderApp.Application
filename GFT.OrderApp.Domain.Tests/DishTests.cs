using GFT.OrderApp.Domain.DishAggregate;
using GFT.OrderApp.Domain.Exceptions;
using GFT.OrderApp.Infrastructure.Exceptions;
using NUnit.Framework;
using System;

namespace GFT.OrderApp.Domain.Tests
{
    [TestFixture]
    public class DishTests
    {
        [Test]
        public void Throw_exception_when_name_is_empty()
        {
            Assert.Throws<GFTValidationException>(() =>
            {
                new Dessert("");
            });
        }

        [Test]
        public void Throw_exception_when_name_is_null()
        {
            Assert.Throws<GFTValidationException>(() =>
            {
                new Dessert(null);
            });
        }

        [Test]
        public void Must_create_a_dish()
        {
             new Dessert("cake");

            Assert.Pass();
        }
    }
}
