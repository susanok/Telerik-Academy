namespace FirstTaskCourses.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SchoolTest
    {
        [TestMethod]
        public void SchoolShouldInitializeProperly()
        {
            var school = new Models.School();
            Assert.IsNotNull(school);
        }
    }
}
