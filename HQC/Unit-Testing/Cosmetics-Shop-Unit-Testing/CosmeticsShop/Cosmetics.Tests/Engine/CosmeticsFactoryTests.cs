using Cosmetics.Common;
using Cosmetics.Contracts;
using Cosmetics.Engine;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Tests.Engine
{
    [TestFixture]
    public class CosmeticsFactoryTests
    {
        [TestCase("")]
        [TestCase(null)]
        public void CreateShampoo_WhenPassedNameIsNullOrEmpty_ShouldThrowNullReferenceException(string name)
        {
            var factory = new CosmeticsFactory();

            Assert.Throws<NullReferenceException>(() => factory.CreateShampoo(name, "Cool", 0.50M, GenderType.Men, 500, UsageType.EveryDay));
        }

        [TestCase("as")]
        [TestCase("too long name for shampoo")]
        public void CreateShampoo_WhenPassedNameIsTooLongOrShort_ShouldThrowIndexOutOfRangeException(string name)
        {
            var factory = new CosmeticsFactory();

            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateShampoo(name, "Cool", 0.50M, GenderType.Men, 500, UsageType.EveryDay));
        }

        [TestCase("")]
        [TestCase(null)]
        public void CreateShampoo_WhenPassedBrandIsNullOrEmpty_ShouldThrowNullReferenceException(string brand)
        {
            var factory = new CosmeticsFactory();

            Assert.Throws<NullReferenceException>(() => factory.CreateShampoo("White+", brand, 0.50M, GenderType.Men, 500, UsageType.EveryDay));
        }

        [TestCase("a")]
        [TestCase("too long brand for shampoo")]
        public void CreateShampoo_WhenPassedBrandIsTooLongOrShort_ShouldThrowIndexOutOfRangeException(string brand)
        {
            var factory = new CosmeticsFactory();

            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateShampoo("White+", brand, 0.50M, GenderType.Men, 500, UsageType.EveryDay));
        }

        
        [Test]
        public void CreateShampoo_WhenPassedParamsAreValid_ShouldReturnNewShampoo()
        {
            var factory = new CosmeticsFactory();

            var shampoo = factory.CreateShampoo("Nivea", "Cool", 0.50M, GenderType.Men, 500, UsageType.EveryDay);

            Assert.IsInstanceOf<IShampoo>(shampoo);
        }

        [TestCase("")]
        [TestCase(null)]
        public void CreateCategory_WhenPassedBrandIsNullOrEmpty_ShouldThrowNullReferenceException(string name)
        {
            var factory = new CosmeticsFactory();

            Assert.Throws<NullReferenceException>(() => factory.CreateCategory(name));
        }

        [TestCase("a")]
        [TestCase("too long name for category")]
        public void CreateCategory_WhenPassedNameIsTooLongOrShort_ShouldThrowIndexOutOfRangeException(string name)
        {
            var factory = new CosmeticsFactory();

            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateCategory(name));
        }

        [Test]
        public void CreateCategory_WhenPassedParamsAreValid_ShouldReturnNewCategory()
        {
            var factory = new CosmeticsFactory();

            var category = factory.CreateCategory("Nivea");

            Assert.IsInstanceOf<ICategory>(category);
        }

        [TestCase("")]
        [TestCase(null)]
        public void CreateToothpaste_WhenPassedNameIsNullOrEmpty_ShouldThrowNullReferenceException(string name)
        {
            var factory = new CosmeticsFactory();

            Assert.Throws<NullReferenceException>(() => factory.CreateToothpaste(name, "White+", 15.50M, GenderType.Men, new List<string>() { "fluor", "bqla" }));
        }

        [TestCase("as")]
        [TestCase("too long name for toothpaste")]
        public void CreateToothpaste_WhenPassedNameIsTooLongOrShort_ShouldThrowIndexOutOfRangeException(string name)
        {
            var factory = new CosmeticsFactory();

            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateToothpaste(name, "White+", 15.50M, GenderType.Men, new List<string>() { "fluor", "bqla" }));

        }

        [TestCase("")]
        [TestCase(null)]
        public void CreateToothpaste_WhenPassedBrandIsNullOrEmpty_ShouldThrowNullReferenceException(string brand)
        {
            var factory = new CosmeticsFactory();

            Assert.Throws<NullReferenceException>(() => factory.CreateToothpaste("White+", brand, 15.50M, GenderType.Men, new List<string>() { "fluor", "bqla" }));
        }

        [TestCase("a")]
        [TestCase("too long brand for toothpaste")]
        public void CreateToothpaste_WhenPassedBrandIsTooLongOrShort_ShouldThrowIndexOutOfRangeException(string brand)
        {
            var factory = new CosmeticsFactory();

            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateToothpaste("White+", brand, 15.50M, GenderType.Men, new List<string>() { "fluor", "bqla" }));

        }

        [TestCase("as,fluor,golqma")]
        [TestCase("golqma,too long brand for toothpaste,bqla")]
        [TestCase("golqma,bqla,too long brand for toothpaste")]
        [TestCase("too long brand for toothpaste,bqla,as")]
        public void CreateToothpaste_WhenPassedIngredientsIsTooLongOrShort_ShouldThrowIndexOutOfRangeException(string listInput)
        {
            var ingredients = listInput.Split(',').ToList();

            var factory = new CosmeticsFactory();

            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateToothpaste("White+", "Nivea", 15.50M, GenderType.Men, ingredients));

        }

        [Test]
        public void CreateShoppingCart_WhenCreateShoppingCart_ShouldAlwaysReturnNewShoppingCart()
        {
            var factory = new CosmeticsFactory();

            var shoppingCart = factory.CreateShoppingCart();

            Assert.IsInstanceOf<IShoppingCart>(shoppingCart);
        }

    }
}
