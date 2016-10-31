namespace SchoolSystemTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using SchoolSystem.Core;
    using SchoolSystem.Interfaces;
    
    [TestClass]
    public class EngineTest
    {
        [TestMethod]
        public void Constructor_WhenAllParametersAreValid_ShouldReturnInstanceOfClassEngine()
        {
            var mockedReader = new Mock<IReader>();
            var mockedWriter = new Mock<IWriter>();

            var engine = new Engine(mockedReader.Object, mockedWriter.Object);
            Assert.IsInstanceOfType(engine, typeof(Engine));
        }
    }
}
