namespace SchoolSystem.Commands
{
    using System.Collections.Generic;
    using Core;
    using Interfaces;

    public class RemoveTeacherCommand : ICommand
    {
        private const string SuccessMessage =
            "Teacher with ID {0} was sucessfully removed.";

        public string Execute(IList<string> parameters)
        {
            var teacherId = int.Parse(parameters[0]);
            Engine.Teachers.Remove(teacherId);
            return string.Format(SuccessMessage, teacherId);
        }
    }
}
