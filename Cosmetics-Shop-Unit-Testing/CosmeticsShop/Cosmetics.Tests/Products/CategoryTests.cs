using Cosmetics.Common;
using Cosmetics.Engine;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Tests.Products
{
    [TestFixture]
    public class CategoryTests
    {
        [Test]
        public void Print_WhenItIsInvoked_ShouldReturnStringWithACategoryDetailsInRequiredFormat()
        {
            var factory = new CosmeticsFactory();

            var category = factory.CreateCategory("example");

           
            var actualResult = category.Print();

            Assert.AreEqual("example category - 0 products in total", actualResult);
        }
    }
}
