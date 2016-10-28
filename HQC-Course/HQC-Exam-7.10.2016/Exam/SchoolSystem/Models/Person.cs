namespace SchoolSystem.Models
{
    using System;
    using System.Text.RegularExpressions;

    public abstract class Person
    {
        private const int MinNameLenght = 2;

        private const int MaxNameLenght = 31;

        private const string ErrorMessageNameLenght = "Name must be between 2 and 31 symbols.";

        private const string ErrorMessageLatinLetters = "Name must contains only Latin letters.";

        private const string Pattern = "^[a-zA-Z0-9]*$";

        private string firstName;

        private string lastName;

        public Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            private set
            {
                if (value.Length < MinNameLenght || value.Length > MaxNameLenght)
                {
                    throw new ArgumentException(ErrorMessageNameLenght);
                }

                if (!Regex.IsMatch(value, Pattern))
                {
                    throw new ArgumentException(ErrorMessageLatinLetters);
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            private set
            {
                if (value.Length < MinNameLenght || value.Length > MaxNameLenght)
                {
                    throw new ArgumentException(ErrorMessageNameLenght);
                }

                if (!Regex.IsMatch(value, Pattern))
                {
                    throw new ArgumentException(ErrorMessageLatinLetters);
                }

                this.lastName = value;
            }
        }
    }
}
