namespace SchoolSystem.Models
{
    using Enums;

    public class Teacher : Person
    {
        public Teacher(string firstName, string lastName, Subject subject)
            : base(firstName, lastName)
        {
            this.Subject = subject;
        }

        public Subject Subject { get; private set; }
    }
}
