namespace SchoolSystem.Models
{
    using System.Collections.Generic;
    using Enums;

    public class Student : Person
    {
        public Student(string firstName, string lastName, Grade studentGrade)
            : base(firstName, lastName)
        {
            this.StudentGrade = studentGrade;
            this.StudentMarks = new List<Mark>();
        }

        public Grade StudentGrade { get; private set; }

        public List<Mark> StudentMarks { get; set; }
    }
}
