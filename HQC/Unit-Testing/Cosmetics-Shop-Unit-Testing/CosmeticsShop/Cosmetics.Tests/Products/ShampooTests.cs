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
    public class ShampooTests
    {
        [Test]
        public void Print_WhenItIsInvoked_ShouldReturnStringWithAShampooDetailsInRequiredFormat()
        {
            var factory = new CosmeticsFactory();

            var shampoo = factory.CreateShampoo("Cool", "Nivea", 10M, GenderType.Men, 500, UsageType.EveryDay);

            var expectedResult = new StringBuilder();
            expectedResult.AppendLine("- Nivea - Cool:");
            expectedResult.AppendLine("  * Price: $5000");
            expectedResult.AppendLine("  * For gender: Men");
            expectedResult.AppendLine("  * Quantity: 500 ml");
            expectedResult.Append("  * Usage: EveryDay");

            var actualResult = shampoo.Print();

            Assert.AreEqual(expectedResult.ToString(), actualResult);
        }
    }
}
