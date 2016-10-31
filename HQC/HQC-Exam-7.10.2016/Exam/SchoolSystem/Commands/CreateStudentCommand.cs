namespace SchoolSystem.Commands
{
    using System.Collections.Generic;
    using Core;
    using Enums;
    using Interfaces;
    using Models;

    public class CreateStudentCommand : ICommand
    {
        private const string SuccessMessage =
            "A new student with name {0} {1}, grade {2} and ID {3} was created.";

        private static int id = 0;

        public string Execute(IList<string> parameters)
        {
            var student = new Student(parameters[0], parameters[1], (Grade)int.Parse(parameters[2]));
            Engine.Students.Add(id, student);
            return string.Format(SuccessMessage, student.FirstName, student.LastName, (Grade)student.StudentGrade, id++);
        }
    }
}
