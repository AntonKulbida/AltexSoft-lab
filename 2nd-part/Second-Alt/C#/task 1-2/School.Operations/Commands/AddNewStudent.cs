using System;
using School.Common.Core;
using School.Data.Entity.Models;
using School.Data.Interfaces;
using School.Operations.Attributes;
using School.Operations.Interfaces;

namespace School.Operations.Commands
{
    [CommandName("add-student")]
    [CommandDescription("add-student", typeof(Strings))]
    public sealed class AddNewStudent : ICommand, IDisposable
    {
        private readonly IStudentRepository _repository;

        public AddNewStudent(IStudentRepository repository)
        {
            _repository = repository;
        }

        public void Execute()
        {
            var newStudent = new Student();

            Console.WriteLine(Strings.EnterStudentsFirtsName);
            newStudent.FirstName = Console.ReadLine();
            Console.WriteLine(Strings.EnterStudentsLastName);
            newStudent.LastName = Console.ReadLine();
            Console.WriteLine(Strings.EnterStudentsAge);
            int age;
            while (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine(Strings.InvalidAgeValue);
            }

            newStudent.Age = age;

            _repository.Add(newStudent);
            _repository.SaveChanges();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
