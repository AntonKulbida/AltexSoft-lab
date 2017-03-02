using System;
using System.Linq;
using School.Common.Core;
using School.Data.Interfaces;
using School.Operations.Attributes;
using School.Operations.Helpers;
using School.Operations.Interfaces;

namespace School.Operations.Commands
{
    [CommandName("del-student")]
    [CommandDescription("del-student", typeof(Strings))]
    public sealed class DeleteStudentCommand : ICommand, IDisposable
    {
        private readonly IStudentRepository _repository;

        public DeleteStudentCommand(IStudentRepository repository)
        {
            _repository = repository;
        }

        public void Execute()
        {
            var students = _repository.GetAll().ToArray();

            students.PrintPersonList(Strings.AllStudents);

            var student = students.PickPerson(Strings.PickStudentToDelete);

            _repository.Delete(student);
            _repository.SaveChanges();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
