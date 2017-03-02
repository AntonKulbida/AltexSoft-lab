using System;
using System.Linq;
using School.Common.Core;
using School.Data.Interfaces;
using School.Operations.Attributes;
using School.Operations.Interfaces;

namespace School.Operations.Commands
{
    [CommandName("print-students")]
    [CommandDescription("print-students", typeof(Strings))]
    public sealed class PrintStudentsDetailedListCommand : ICommand, IDisposable
    {
        private readonly IStudentRepository _repository;

        public PrintStudentsDetailedListCommand(IStudentRepository repository)
        {
            _repository = repository;
        }

        public void Execute()
        {
            foreach (var student in _repository.GetAllIncludeTeacher().OrderBy(t => t.FirstName))
            {
                Console.WriteLine(student);

                if (student.Teacher == null)
                {
                    Console.WriteLine(Strings.NestedElementFormat, Strings.NoTeacherAssigned);
                    continue;
                }

                Console.WriteLine(Strings.NestedElementFormat, student.Teacher);
            }
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
