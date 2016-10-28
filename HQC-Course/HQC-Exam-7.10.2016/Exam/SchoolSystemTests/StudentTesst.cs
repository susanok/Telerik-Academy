namespace SchoolSystemTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SchoolSystem.Enums;
    using SchoolSystem.Models;
    using System;

    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void Constructor_WhenAllParametersAreValid_ShouldReturnInstanceOfClassStudent()
        {
            var student = new Student("example", "example", (Grade)2);

            Assert.IsInstanceOfType(student, typeof(Student));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_WhenNameIsNotInRange_ShouldThrowArgumentException()
        {
            var student = new Student("e", "example", (Grade)2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_WhenNameIsNotWithLatinLetters_ShouldThrowArgumentException()
        {
            var student = new Student("алекс", "example", (Grade)2);
        }
    }
}
