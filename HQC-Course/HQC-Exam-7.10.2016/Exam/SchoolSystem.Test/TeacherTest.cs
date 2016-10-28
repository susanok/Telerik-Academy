namespace SchoolSystem.Test
{
    using NUnit.Framework;
    using SchoolSystem.Models;

    [TestFixture]
    public class TeacherTest
    {
        [Test]
        public void Constructor_WhenItIsInvokedWithActualParameters_ShouldReturnNewlyCreatedTeacher()
        {
            var firstName = "firstName";
            var lastName = "lastName";
            var subject = 2;
            var teacher = new Teacher(firstName, lastName, (Subject)subject);

            Assert.IsInstanceOf(typeof(Teacher), teacher);
        }
    }
}
