using Cosmetics.Contracts;
using Cosmetics.Tests.MockedClasses;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Tests.Products
{
    [TestFixture]
    public class ShoppingCartTests
    {
        [Test]
        public void AddProduct_WhenValidProductIsPassed_ShouldBeAddedToListWithProducts()
        {
            var mockedProduct = new Mock<IProduct>();

            var mockedShoppingCart = new MockedShoppingCart();
            mockedShoppingCart.AddProduct(mockedProduct.Object);

            Assert.IsTrue(mockedShoppingCart.Products.Contains(mockedProduct.Object));
        }

        [Test]
        public void RemoveProduct_WhenValidProductIsPassed_ShouldBeremovedFromListWithProducts()
        {
            var mockedProduct = new Mock<IProduct>();

            var mockedShoppingCart = new MockedShoppingCart();
            mockedShoppingCart.AddProduct(mockedProduct.Object);

            mockedShoppingCart.RemoveProduct(mockedProduct.Object);
            Assert.IsFalse(mockedShoppingCart.Products.Contains(mockedProduct.Object));
        }

        [Test]
        public void ContainsProduct_WhenValidProductIsPassed_ShouldReturnTrue()
        {
            var mockedProduct = new Mock<IProduct>();

            var mockedShoppingCart = new MockedShoppingCart();
            mockedShoppingCart.AddProduct(mockedProduct.Object);

            Assert.IsTrue(mockedShoppingCart.ContainsProduct(mockedProduct.Object));
        }

        [Test]
        public void TotalPrice_WhenProductsListIsEmpty_ShouldReturnZero()
        {
            var mockedProduct = new Mock<IProduct>();

            var mockedShoppingCart = new MockedShoppingCart();
            
            Assert.AreEqual(0m, mockedShoppingCart.TotalPrice());
        }

        [Test]
        public void TotalPrice_WhenProductsListHasProducts_ShouldReturnCorrectToTalPrice()
        {
            var firstMockedProduct = new Mock<IProduct>();
            var secondMockedproduct = new Mock<IProduct>();

            firstMockedProduct.SetupGet(x => x.Price).Returns(10M);
            secondMockedproduct.SetupGet(x => x.Price).Returns(20M);

            var mockedShoppingCart = new MockedShoppingCart();

            mockedShoppingCart.AddProduct(firstMockedProduct.Object);
            mockedShoppingCart.AddProduct(secondMockedproduct.Object);

            Assert.AreEqual(30m, mockedShoppingCart.TotalPrice());
        }
    }
}
