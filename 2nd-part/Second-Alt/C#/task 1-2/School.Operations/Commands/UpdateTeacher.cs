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
    
        [CommandName("up-teacher")]
        [CommandDescription("up-teacher", typeof(Strings))]
        public sealed class UpdateTeacherCommand : ICommand, IDisposable
        {
            private readonly ITeacherRepository _repository;

            public UpdateTeacherCommand(ITeacherRepository repository)
            {
                _repository = repository;
            }


            public void Execute()
            {
                var teachers = _repository.GetAll().ToArray();

                teachers.PrintPersonList(Strings.AllTeachers);

                var teacher = teachers.PickPerson(Strings.PickTeacherToUpdate);
                var newTeacher = teacher;
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
                _repository.Update(newTeacher);
                _repository.SaveChanges();
            }

            public void Dispose()
            {
                _repository.Dispose();
            }
        }
}
