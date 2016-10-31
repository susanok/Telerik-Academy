namespace SchoolSystemTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SchoolSystem.Enums;
    using SchoolSystem.Models;

    [TestClass]
    public class MarkTest
    {
        [TestMethod]
        public void Constructor_WhenAllParametersAreValid_ShouldReturnInstanceOfClassMark()
        {
            var mark = new Mark((Subject)2, 3.8f);

            Assert.IsInstanceOfType(mark, typeof(Mark));
        }
    }
}
