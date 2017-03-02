using System;
using System.Linq;
using School.Common.Core;
using School.Data.Interfaces;
using School.Operations.Attributes;
using School.Operations.Helpers;
using School.Operations.Interfaces;

namespace School.Operations.Commands
{
    [CommandName("revoke-teacher")]
    [CommandDescription("revoke-teacher", typeof(Strings))]
    public sealed class RevokeTeacherFromStudent : ICommand, IDisposable
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ITeacherRepository _teacherRepository;

        public RevokeTeacherFromStudent(IStudentRepository studentRepository, ITeacherRepository teacherRepository)
        {
            _studentRepository = studentRepository;
            _teacherRepository = teacherRepository;
        }

        public void Execute()
        {
            var teachers = _teacherRepository.GetListIncludeStudents(t => t.Students.Any()).ToArray();

            teachers.PrintPersonList(Strings.AllTeachersWithAssignedStudents);

            var teacher = teachers.PickPerson(Strings.PickTeacherToRevoke);

            var students = teacher.Students.ToArray();

            var teacherFullName = String.Format(Strings.PersonFullNameFormat, teacher.FirstName, teacher.LastName);
            students.PrintPersonList(String.Format(Strings.AllStudentsAssignedToTheTeacherFormat, teacherFullName));

            var student = students.PickPerson(Strings.PickStudentToRevoke);

            student.Teacher = null;
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
