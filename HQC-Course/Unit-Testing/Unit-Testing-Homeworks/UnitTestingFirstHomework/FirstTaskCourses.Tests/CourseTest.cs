namespace FirstTaskCourses.Tests
{
    using Exceptions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;

    [TestClass]
    public class CourseTest
    {
        [TestMethod]
        public void CourseShouldInitializeProperly()
        {
            var course = new Course();
            Assert.IsNotNull(course);
        }

        [TestMethod]
        [ExpectedException(typeof(CourseException))]
        public void CourseJoinMethodShouldThrowsACourseExceptionBecauseTheGivenStudentISNull()
        {
            var course = new Course();
            course.JoinCourse(null);
        }

        [TestMethod]
        [ExpectedException(typeof(CourseException))]
        public void CourseJoinMethodShouldThrowsACourseExceptionBecauseStudentsAreTooMany()
        {
            int count = 10001;
            var course = new Course();
            for (int i = 0; i < 31; i++)
            {
                course.JoinCourse(new Student("Gosho", count));
                count++;
            }

        }

        [TestMethod]
        [ExpectedException(typeof(CourseException))]
        public void CourseLeaveMethodShouldThrowsACourseExceptionBecauseTheGivenStudentISNull()
        {
            var course = new Course();
            course.LeaveCourse(null);
        }
    }
}