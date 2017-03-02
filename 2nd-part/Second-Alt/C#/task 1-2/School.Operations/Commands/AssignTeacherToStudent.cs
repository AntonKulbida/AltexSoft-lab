using System;
using System.Linq;
using School.Common.Core;
using School.Data.Interfaces;
using School.Operations.Attributes;
using School.Operations.Helpers;
using School.Operations.Interfaces;

namespace School.Operations.Commands
{
    [CommandName("assign-teacher")]
    [CommandDescription("assign-teacher", typeof(Strings))]
    public sealed class AssignTeacherToStudent : ICommand, IDisposable
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ITeacherRepository _teacherRepository;

        public AssignTeacherToStudent(IStudentRepository studentRepository, ITeacherRepository teacherRepository)
        {
            _studentRepository = studentRepository;
            _teacherRepository = teacherRepository;
        }

        public void Execute()
        {
            var teachers = _teacherRepository.GetAll().ToArray();

            teachers.PrintPersonList(Strings.AllTeachers);

            var teacher = teachers.PickPerson(Strings.PickTeacherToAssign);

            var students = _studentRepository.GetList(s => teacher.Id != s.TeacherId).ToArray();

            if (!students.Any())
            {
                Console.WriteLine(Strings.NoStudentsToAssign);
                return;
            }

            students.PrintPersonList(Strings.AllStudents);

            var student = students.PickPerson(Strings.PickStudentToAssign);

            student.Teacher = teacher;
            _studentRepository.Update(student);
            _studentRepository.SaveChanges();
        }

        public void Dispose()
        {
            _studentRepository.Dispose();
            _teacherRepository.Dispose();
        }
    }
}
