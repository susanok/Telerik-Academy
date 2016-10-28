namespace SchoolSystem.Commands
{
    using System.Collections.Generic;
    using System.Linq;
    using Core;
    using Interfaces;

    public class StudentListMarksCommand : ICommand
    {
        private const string SuccessMessage = "The student has these marks:\n";

        private const string ErrorMessage = "This student has no marks.";

        public string Execute(IList<string> parameters)
        {
            var studentId = int.Parse(parameters[0]);
            var student = Engine.Students[studentId];
            if (student.StudentMarks.Count > 0)
            {
                var studentMarks = student.StudentMarks.Select(m => $"{m.Subject} => {m.Value}").ToList();
                var result = SuccessMessage + string.Join("\n", studentMarks);
                return result;
            }
            else
            {
                return ErrorMessage;
            }
        }
    }
}
