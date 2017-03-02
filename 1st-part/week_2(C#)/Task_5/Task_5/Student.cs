using System;
using System.Linq;
using System.Text;


namespace Task_5
{
    public class Student : Person
    {
        public string Faculty { get; set; }
        public byte Course { get; set; }
        public int TeacherID { get; set; }

        public Student()
        {
        }

        public Student(string name, string surname, byte age, string faculty, byte course, int teacherId)
            : base(name, surname, age)
        {
            this.Faculty = faculty;
            this.Course = course;
            this.TeacherID = teacherId;
        }


        public new virtual void Print()
        {
            Console.WriteLine("Name: {0}\nSurname: {1}\nAge: {2}\nFaculty: {3}\nCourse: {4}\n", Name, Surname, Age, Faculty, Course);
        }

        public override string ToString()
        {
            return String.Format(base.ToString() + "\nFaculty: {0}\nCourse: {1}", Faculty, Course);
        }
    }
}
