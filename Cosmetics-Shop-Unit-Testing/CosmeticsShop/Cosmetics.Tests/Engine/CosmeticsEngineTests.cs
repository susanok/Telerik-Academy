using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Contracts;
using Cosmetics.Tests.MockedClasses;
using Cosmetics.Common;

namespace Cosmetics.Tests.Engine
{
    [TestFixture]
    public class CosmeticsEngineTests
    {
        [Test]
        public void Start_WhenInputIsValidCreateCategoryCommand_CategorySholudBeAddToList()
        {
            var commandName = "CreateCategory";
            var categoryName = "ForMale";

            // mock the dependencies that engine constructor needs
            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedParser = new Mock<ICommandParser>();

            // objects that need to create fake category and command and then add the category to the list
            var mockedCommand = new Mock<ICommand>();
            var mockedCategory = new Mock<ICategory>();

            //setup the behaviour of getters of the command
            mockedCommand.SetupGet(x => x.Name).Returns(commandName);
            mockedCommand.SetupGet(x => x.Parameters).Returns(new[] { categoryName });

            //setup the ReadCommands method behaviour to returns a list with the mocked command
            mockedParser.Setup(x => x.ReadCommands())
                .Returns(new List<ICommand>() { mockedCommand.Object });

            mockedCategory.SetupGet(x => x.Name).Returns(categoryName);
            mockedFactory.Setup(x => x.CreateCategory(categoryName))
                .Returns(mockedCategory.Object);

            var engine = new MockedCosmeticsEngine(
                mockedFactory.Object,
                mockedShoppingCart.Object, 
                mockedParser.Object);

            engine.Start();

            Assert.IsTrue(engine.Categories.ContainsKey(categoryName));
            Assert.AreSame(mockedCategory.Object, engine.Categories[categoryName]);
        }

        [Test]
        public void Start_WhenInputIsValidAddToCategoryCommand_ProductSholudBeAddToListToTheCategory()
        {
            var commandName = "AddToCategory";
            var categoryName = "ForMale";
            var productName = "Cool";

            // mock the dependencies that engine constructor needs
            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedParser = new Mock<ICommandParser>();

            // objects that need to create fake category and command and then add the category to the list
            var mockedCommand = new Mock<ICommand>();
            var mockedCategory = new Mock<ICategory>();
            var mockedShampoo = new Mock<IShampoo>(); 

            //setup the behaviour of getters of the command
            mockedCommand.SetupGet(x => x.Name).Returns(commandName);
            mockedCommand.SetupGet(x => x.Parameters).Returns(new[] { categoryName, productName});
            mockedShampoo.SetupGet(x => x.Name).Returns(productName);

            //setup the ReadCommands method behaviour to returns a list with the mocked command
            mockedParser.Setup(x => x.ReadCommands())
                .Returns(new List<ICommand>() { mockedCommand.Object });

            var engine = new MockedCosmeticsEngine(
                mockedFactory.Object,
                mockedShoppingCart.Object,
                mockedParser.Object);

            engine.Categories.Add(categoryName, mockedCategory.Object);
            engine.Products.Add(productName, mockedShampoo.Object);

            engine.Start();

            mockedCategory.Verify(x => x.AddProduct(mockedShampoo.Object), Times.Once);

        }

        [Test]
        public void Start_RemoveFromCategoryInputIsValid_ProductShouldBeRemoveFromTheCategory()
        {
            var commandName = "RemoveFromCategory";
            var categoryName = "ForMale";
            var productName = "Cool";

            //mock the objects for the engine constructor
            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedParser = new Mock<ICommandParser>();

            //mock the objects that needs to process the command
            var mockedCommand = new Mock<ICommand>();
            var mockedCategory = new Mock<ICategory>();
            var mockedShampoo = new Mock<IShampoo>();

            // setup the fake command getters to return correct things
            mockedCommand.Setup(x => x.Name).Returns(commandName);
            mockedCommand.Setup(x => x.Parameters).Returns(new List<string>() { categoryName, productName });

            //setup the fake product to return the name we need to remove it from the list
            mockedShampoo.SetupGet(x => x.Name).Returns(productName);

            //setup the ReadCommands method
            //behaviour to returns a list with the mocked command
            mockedParser.Setup(x => x.ReadCommands())
                .Returns(new List<ICommand>() { mockedCommand.Object });

            //mock the engine
            var engine = new MockedCosmeticsEngine(
                mockedFactory.Object,
                mockedShoppingCart.Object,
                mockedParser.Object);

            //add the category and the product to can later remove it
            engine.Categories.Add(categoryName, mockedCategory.Object);
            engine.Products.Add(productName, mockedShampoo.Object);
            engine.Categories[categoryName].AddProduct(mockedShampoo.Object);

            //Act
            engine.Start();

            //check that remove is called
            mockedCategory.Verify(x => x.RemoveProduct(mockedShampoo.Object), Times.Once);

        }

        [Test]
        public void Start_ShowCategoryInputIsValid_ThePrintMethodOfTheRespectiveCategoryShouldbeCalled()
        {
            var commandName = "ShowCategory";
            var categoryName = "ForMale";

            //mock the objects for the engine constructor
            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedParser = new Mock<ICommandParser>();

            //mock the objects that needs to process the command
            var mockedCategory = new Mock<ICategory>();
            var mockedCommand = new Mock<ICommand>();

            // setup the fake command getters to return correct things
            mockedCommand.SetupGet(x => x.Name).Returns(commandName);
            mockedCommand.SetupGet(x => x.Parameters).Returns(new List<string>() { categoryName });
            mockedCategory.SetupGet(x => x.Name).Returns(categoryName);

            //setup the ReadCommands method
            //behaviour to returns a list with the mocked command
            mockedParser.Setup(x => x.ReadCommands())
                .Returns(new List<ICommand>() { mockedCommand.Object });

            //mock the engine
            var engine = new MockedCosmeticsEngine(
                mockedFactory.Object,
                mockedShoppingCart.Object,
                mockedParser.Object);

            //add the category in the list of categories
            engine.Categories.Add(categoryName, mockedCategory.Object);

            //Act
            engine.Start();

            //check that print is called
            mockedCategory.Verify(x => x.Print(), Times.Once);

        }

        [Test]
        public void Start_CreateShampooInputIsValid_ShouldBeAddedTheNewShampooToTheListOfProducts()
        {
            var commandName = "CreateShampoo";
            var shampooName = "Cool";
            var shampoBrand = "Nivea";
            var shampooPrice = "0,50";
            var shampooGender = "men";
            var shampooMililiters = "500";
            var shampooUsage = "everyday";

            //mock the objects for the engine constructor
            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedParser = new Mock<ICommandParser>();

            //mock the objects that needs to process the command
            var mockedShampoo = new Mock<IShampoo>();
            var mockedCommand = new Mock<ICommand>();

            // setup the fake command getters to return correct things
            mockedCommand.SetupGet(x => x.Name).Returns(commandName);
            mockedCommand.SetupGet(x => x.Parameters)
                .Returns(new List<string>() {
                    shampooName,
                    shampoBrand,
                    shampooPrice,
                    shampooGender,
                    shampooMililiters,
                    shampooUsage });


            mockedFactory.Setup(x => x.CreateShampoo(shampooName, shampoBrand, 0.50M, GenderType.Men, 500, UsageType.EveryDay))
                .Returns(mockedShampoo.Object);
            //setup the ReadCommands method
            //behaviour to returns a list with the mocked command
            mockedParser.Setup(x => x.ReadCommands())
                .Returns(new List<ICommand>() { mockedCommand.Object });

            //mock the engine
            var engine = new MockedCosmeticsEngine(
                mockedFactory.Object,
                mockedShoppingCart.Object,
                mockedParser.Object);

            //Act
            engine.Start();

            //check that shampoo is added
            Assert.IsTrue(engine.Products.ContainsKey(shampooName));
            Assert.AreSame(mockedShampoo.Object, engine.Products[shampooName]);  
        }

        [Test]
        public void Start_CreateToothpasteInputIsValid_ShouldBeAddedTheNewToothPasteToTheListOfProducts()
        {
            //CreateToothpaste White+ Colgate 15.50 men fluor,bqla,golqma
            var commandName = "CreateToothpaste";
            var pasteName = "White+";
            var pasteBrand = "Colgate";
            var pastePrice = "15,50";
            var pasteGender = "men";
            var pasteIngredients = "fluor,bqla,golqma";
            var listOfIngredients = new List<string>() { "fluor", "bqla", "golqma" };

            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedParser = new Mock<ICommandParser>();

            var mockedCommand = new Mock<ICommand>();
            var mockedToothPaste = new Mock<IToothpaste>();

            mockedCommand.SetupGet(x => x.Name).Returns(commandName);
            mockedCommand.SetupGet(x => x.Parameters).Returns(new List<string>()
            {
                pasteName, pasteBrand, pastePrice, pasteGender, pasteIngredients
            });

            mockedParser.Setup(x => x.ReadCommands())
                .Returns(new List<ICommand>() { mockedCommand.Object });

            var engine = new MockedCosmeticsEngine(
                mockedFactory.Object,
                mockedShoppingCart.Object,
                mockedParser.Object);

            mockedFactory.Setup(x => x.CreateToothpaste(
                pasteName,
                pasteBrand,
                15.50M,
                GenderType.Men,
                listOfIngredients));

            mockedFactory.Setup(x => x.CreateToothpaste(pasteName, pasteBrand, 15.50M, GenderType.Men, listOfIngredients))
                .Returns(mockedToothPaste.Object);

            engine.Start();

            Assert.IsTrue(engine.Products.ContainsKey(pasteName));
            Assert.AreSame(mockedToothPaste.Object, engine.Products[pasteName]);
        }

        [Test]
        public void Start_AddToShoppingCartInputIsValid_ShouldBeAddedTheProductToTheShoppingCart()
        {
            var commandName = "AddToShoppingCart";
            var productName = "White+";

            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedParser = new Mock<ICommandParser>();

            var mockedCommand = new Mock<ICommand>();
            var mockedToothpaste = new Mock<IToothpaste>();

            mockedCommand.SetupGet(x => x.Name).Returns(commandName);
            mockedCommand.SetupGet(x => x.Parameters).Returns(new List<string>() { productName });
            mockedToothpaste.SetupGet(x => x.Name).Returns(productName);

            mockedParser.Setup(x => x.ReadCommands()).Returns(new List<ICommand>() { mockedCommand.Object });

            var engine = new MockedCosmeticsEngine(
                mockedFactory.Object,
                mockedShoppingCart.Object,
                mockedParser.Object);

            engine.Products.Add(productName, mockedToothpaste.Object);

            engine.Start();

            mockedShoppingCart.Verify(x => x.AddProduct(mockedToothpaste.Object), Times.Once);
        }

        [Test]
        public void Start_RemoveFromShoppingCartInputIsValid_ShouldRemoveTheProductFromTheShoppingCart()
        {
            var commandName = "RemoveFromShoppingCart";
            var productName = "Cool";

            //mock objects for the engine constructor
            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingCart = new Mock<IShoppingCart>();
            var mockedParser = new Mock<ICommandParser>();

            //mock the fake command and the fake product
            var mockedCommand = new Mock<ICommand>();
            var mockedShampoo = new Mock<IShampoo>();

            //setup mocked command name and parameters to return expected things
            mockedCommand.SetupGet(x => x.Name).Returns(commandName);
            mockedCommand.SetupGet(x => x.Parameters).Returns(new List<string>() { productName });

            //setup the fake product name to return expected name
            mockedShampoo.SetupGet(x => x.Name).Returns(productName);

            //setup the mocked parser who should reads the commands and returns list with the mocked command
            mockedParser.Setup(x => x.ReadCommands()).Returns(new List<ICommand>() { mockedCommand.Object });

            //mock the engine
            var engine = new MockedCosmeticsEngine(
                mockedFactory.Object,
                mockedShoppingCart.Object,
                mockedParser.Object);

            //add the mocked product to the mocked engine
            engine.Products.Add(productName, mockedShampoo.Object);

            //add the mocked product to the mocked shopping cart
            mockedShoppingCart.Setup(x => x.ContainsProduct(mockedShampoo.Object)).Returns(true);

            engine.Start();

            mockedShoppingCart.Verify(x => x.RemoveProduct(mockedShampoo.Object), Times.Once);
        }
    }
}
