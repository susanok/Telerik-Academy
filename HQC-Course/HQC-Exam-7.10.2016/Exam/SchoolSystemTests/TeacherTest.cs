namespace SchoolSystemTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SchoolSystem.Enums;
    using SchoolSystem.Models;
    using System;

    [TestClass]
    public class StudentTesst
    {
        [TestMethod]
        public void Constructor_WhenAllParametersAreValid_ShouldReturnInstanceOfClassTeacher()
        {
            var teacher = new Teacher("example", "example", (Subject)2);

            Assert.IsInstanceOfType(teacher, typeof(Teacher));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_WhenNameIsNotInRange_ShouldThrowArgumentException()
        {
            var teacher = new Teacher("e", "example", (Subject)2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_WhenNameIsNotWithLatinLetters_ShouldThrowArgumentException()
        {
            var teacher = new Teacher("алекс", "example", (Subject)2);
        }
    }
}
