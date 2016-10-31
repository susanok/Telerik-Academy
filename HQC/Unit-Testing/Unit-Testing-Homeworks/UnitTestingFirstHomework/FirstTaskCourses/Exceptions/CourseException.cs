namespace FirstTaskCourses.Exceptions
{
    using System;

    public class CourseException : ArgumentException
    {

        public CourseException(string msg)
            : base(msg)
        {
        }
    }
}
