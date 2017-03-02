using System;
using System.Linq;
using School.Common.Core;
using School.Data.Interfaces;
using School.Operations.Attributes;
using School.Operations.Interfaces;

namespace School.Operations.Commands
{
    [CommandName("print-teachers")]
    [CommandDescription("print-teachers", typeof(Strings))]
    public sealed class PrintTeachersDetailedListCommand : ICommand, IDisposable
    {
        private readonly ITeacherRepository _repository;

        public PrintTeachersDetailedListCommand(ITeacherRepository repository)
        {
            _repository = repository;
        }

        public void Execute()
        {
            foreach (var teacher in _repository.GetAllIncludeStudents().OrderBy(t => t.FirstName))
            {
                Console.WriteLine(teacher);

                if (!teacher.Students.Any())
                {
                    Console.WriteLine(Strings.NestedElementFormat, Strings.NoStudents);
                    continue;
                }

                foreach (var student in teacher.Students.OrderBy(s => s.FirstName))
                {
                    Console.WriteLine(Strings.NestedElementFormat, student);
                }
            }
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
