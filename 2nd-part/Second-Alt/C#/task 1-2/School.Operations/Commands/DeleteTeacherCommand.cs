using System;
using System.Linq;
using School.Common.Core;
using School.Data.Interfaces;
using School.Operations.Attributes;
using School.Operations.Helpers;
using School.Operations.Interfaces;

namespace School.Operations.Commands
{
    [CommandName("del-teacher")]
    [CommandDescription("del-teacher", typeof(Strings))]
    public sealed class DeleteTeacherCommand : ICommand, IDisposable
    {
        private readonly ITeacherRepository _repository;

        public DeleteTeacherCommand(ITeacherRepository repository)
        {
            _repository = repository;
        }

        public void Execute()
        {
            var teachers = _repository.GetAll().ToArray();

            teachers.PrintPersonList(Strings.AllTeachers);

            var teacher = teachers.PickPerson(Strings.PickTeacherToDelete);

            _repository.Delete(teacher);
            _repository.SaveChanges();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
