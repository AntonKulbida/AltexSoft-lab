using System;
using System.Collections.Generic;
using System.Linq;
using School.Common.Core;
using School.Data.Interfaces;
using School.Operations.Attributes;
using School.Operations.Helpers;
using School.Operations.Interfaces;
using School.Data.Entity.Models;


namespace School.Operations.Commands
{
    [CommandName("up-student")]
    [CommandDescription("up-student", typeof(Strings))]
    public sealed class UpdateStudentCommand: ICommand, IDisposable
    {
        private readonly IStudentRepository _repository;

        public UpdateStudentCommand(IStudentRepository repository)
        {
            _repository = repository;
        }


        public void Execute()
        {
            var students = _repository.GetAll().ToArray();

            students.PrintPersonList(Strings.AllStudents);

            var student = students.PickPerson(Strings.PickStudentToUpdate);
            var newStudent =student;
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
            _repository.Update(newStudent);
            _repository.SaveChanges();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
