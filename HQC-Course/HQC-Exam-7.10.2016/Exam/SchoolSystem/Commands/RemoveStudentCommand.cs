namespace SchoolSystem.Commands
{
    using System.Collections.Generic;
    using Core;
    using Interfaces;

    public class RemoveStudentCommand : ICommand
    {
        private const string SuccessMessage =
            "Student with ID {0} was sucessfully removed.";

        public string Execute(IList<string> parameters)
        {
            var studentId = int.Parse(parameters[0]);
            Engine.Students.Remove(studentId);
            return string.Format(SuccessMessage, studentId);
        }
    }
}
