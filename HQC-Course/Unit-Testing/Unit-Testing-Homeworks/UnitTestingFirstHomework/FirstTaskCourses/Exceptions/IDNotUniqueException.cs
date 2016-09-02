namespace FirstTaskCourses.Exceptions
{
    using System;

    public class IDNotUniqueException : ArgumentException
    {

        public IDNotUniqueException(string msg)
            : base(msg)
        {
        }
    }
}
