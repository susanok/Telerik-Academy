namespace SchoolSystem.Commands
{
    using System.Collections.Generic;
    using Core;
    using Enums;
    using Interfaces;
    using Models;

    public class CreateTeacherCommand : ICommand
    {
        private const string SuccessMessage =
            "A new teacher with name {0} {1}, subject {2} and ID {3} was created.";

        private static int id = 0;

        public string Execute(IList<string> parameters)
        {
            var teacher = new Teacher(parameters[0], parameters[1], (Subject)int.Parse(parameters[2]));
            Engine.Teachers.Add(id, teacher);
            return string.Format(SuccessMessage, teacher.FirstName, teacher.LastName, teacher.Subject, id++);
        }
    }
}
