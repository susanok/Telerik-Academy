namespace FirstTaskCourses.Models
{
    using Exceptions;
    using Helpers;

    public class Student
    {
        private string name;
        private int uniqueNumber;

        public Student(string name, int uniqueNumber)
        {
            this.Name = name;
            this.UniqueNumber = uniqueNumber;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new NullOrEmptyException(Messages.NameCanNotBeNullOrEmpty);
                }

                this.name = value;
            }
        }

        public int UniqueNumber
        {
            get
            {
                return this.uniqueNumber;
            }
            private set
            {
                if (value < 10000 || value > 99999)
                {
                    throw new IDNotUniqueException(Messages.IDIsNotUnique);
                }

                this.uniqueNumber = value;
            }
        }
    }
}