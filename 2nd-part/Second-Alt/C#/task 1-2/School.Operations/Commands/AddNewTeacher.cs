using System;
using School.Common.Core;
using School.Data.Entity.Models;
using School.Data.Interfaces;
using School.Operations.Attributes;
using School.Operations.Interfaces;

namespace School.Operations.Commands
{
    [CommandName("add-teacher")]
    [CommandDescription("add-teacher", typeof(Strings))]
    public sealed class AddNewTeacher : ICommand, IDisposable
    {
        private readonly ITeacherRepository _repository;

        public AddNewTeacher(ITeacherRepository repository)
        {
            _repository = repository;
        }

        public void Execute()
        {
            var newTeacher = new Teacher();

            Console.WriteLine(Strings.EnterTeachersFirtsName);
            newTeacher.FirstName = Console.ReadLine();
            Console.WriteLine(Strings.EnterTeachersLastName);
            newTeacher.LastName = Console.ReadLine();
            Console.WriteLine(Strings.EnterTeachersAge);
            int age;
            while (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine(Strings.InvalidAgeValue);
            }

            newTeacher.Age = age;

            _repository.Add(newTeacher);
            _repository.SaveChanges();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
