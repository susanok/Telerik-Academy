namespace SchoolSystem.Commands
{
    using System.Collections.Generic;
    using Core;
    using Interfaces;
    using Models;

    public class TeacherAddMarkCommand : ICommand
    {
        private const string SuccessMessage =
            "Teacher {0} {1} added mark {2} to student {3} {4} in {5}.";

        public string Execute(IList<string> parameters)
        {
            var teacherId = int.Parse(parameters[0]);
            var studentId = int.Parse(parameters[1]);
            var student = Engine.Students[studentId];
            var teacher = Engine.Teachers[teacherId];
            student.StudentMarks.Add(
                new Mark(teacher.Subject, float.Parse(parameters[2])));

            return string.Format(
                SuccessMessage,
                teacher.FirstName,
                teacher.LastName,
                float.Parse(parameters[2]),
                student.FirstName,
                student.LastName,
                teacher.Subject);
        }
    }
}
