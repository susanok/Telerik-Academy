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
    public class ToothpasteTests
    {
        [Test]
        public void Print_WhenItIsInvoked_ShouldReturnStringWithAToothpasteDetailsInRequiredFormat()
        {
            var factory = new CosmeticsFactory();

            var toothPaste = factory.CreateToothpaste("Cool", "Nivea", 10M, GenderType.Men, new List<string>() { "fluor", "golqma"});

            var expectedResult = new StringBuilder();
            expectedResult.AppendLine("- Nivea - Cool:");
            expectedResult.AppendLine("  * Price: $10");
            expectedResult.AppendLine("  * For gender: Men");
            expectedResult.AppendFormat("  * Ingredients: {0}", String.Join(", ", new List<string>() { "fluor", "golqma" }));

            var actualResult = toothPaste.Print();

            Assert.AreEqual(expectedResult.ToString(), actualResult);
        }
    }
}
