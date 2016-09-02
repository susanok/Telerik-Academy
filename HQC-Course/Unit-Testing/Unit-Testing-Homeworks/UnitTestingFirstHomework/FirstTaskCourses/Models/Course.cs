namespace FirstTaskCourses.Models
{
    using Exceptions;
    using Helpers;
    using System.Collections.Generic;

    public class Course
    {
        private IList<Student> students;

        public Course()
        {
            this.students = new List<Student>();
        }

        public void JoinCourse(Student studentToJoin)
        {
            if (studentToJoin == null)
            {
                throw new CourseException(Messages.StudentIsNotAnExistingObject);
            }

            if (this.students.Count == 30)
            {
                throw new CourseException(Messages.StudentsInCourses);
            }

            this.students.Add(studentToJoin);
        }

        public void LeaveCourse(Student studentToLeave)
        {
            if (studentToLeave == null)
            {
                throw new CourseException(Messages.StudentIsNotAnExistingObject);
            }

            this.students.Remove(studentToLeave);
        }
    }
}