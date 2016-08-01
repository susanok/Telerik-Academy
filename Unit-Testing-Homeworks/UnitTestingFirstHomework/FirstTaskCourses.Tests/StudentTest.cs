namespace FirstTaskCourses.Tests
{
    using Exceptions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;

    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        [ExpectedException(typeof(IDNotUniqueException))]
        public void StudentShouldThrowsAnIdExceptionBecauseNumIsTooSmall()
        {
            var student = new Student("Pesho", 0);
        }

        [TestMethod]
        [ExpectedException(typeof(IDNotUniqueException))]
        public void StudentShouldThrowsAnIdExceptionBecauseNumIsTooBig()
        {
            var student = new Student("Pesho", 100000);
        }

        [TestMethod]
        [ExpectedException(typeof(NullOrEmptyException))]
        public void StudentShouldThrowsAnNullOrEmptyExceptionBecauseObjectISNull()
        {
            var student = new Student(null, 10003);
        }

        [TestMethod]
        [ExpectedException(typeof(NullOrEmptyException))]
        public void StudentShouldThrowsAnNullOrEmptyExceptionBecauseObjectIsEmpty()
        {
            var student = new Student("", 10003);
        }

        [TestMethod]
        public void StudentShouldInitializeProperly()
        {
            var student = new Student("Pesho", 10003);
            Assert.IsNotNull(student);
        }
    }
}