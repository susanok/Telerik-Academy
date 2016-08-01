namespace FirstTaskCourses.Exceptions
{
    using System;

    public class NullOrEmptyException : ArgumentException
    {
        public NullOrEmptyException(string msg)
            : base(msg)
        {
        }
    }
}
