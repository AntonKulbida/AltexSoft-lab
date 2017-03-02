using System;
using System.Collections;
using System.Linq;


namespace Task_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Person[] person = Person();
            Student[] student = Student();
            Teacher[] teacher = Teacher();

            TaskHelper.TeacherStudents(teacher, student);
            TaskHelper.OverridedToString(person, teacher, student);
            Console.WriteLine();
            TaskHelper.GetInnetTypes(student);

            Console.ReadKey();
        }

        static Person[] Person()
        {
            Person[] arrPersons = new Person[]
            {
                new Person("Hellen", "Kirova", 28),
                new Person("Stas", "Levin", 31),
                new Person("Anna", "Sidorova", 35),
                new Person("Katrin", "Karpova", 30),
                new Person("Petro", "Ivanov", 40),
            };
            return arrPersons;
        }

        static Student[] Student()
        {
            Student[] arrStudents = new Student[]
            {
                new Student("June", "McKenzie", 19, "Programming", 3,1),
                new Student("Mathew", "Domin", 22, "Programming", 4,1),
                new Student("Inna", "Bulkina", 18, "Programming", 1,1),
                new Student("Leev", "Shelton", 21, "History", 3,2),
                new Student("Gragory", "Koozie", 20, "History", 2,2)
            };
            return arrStudents;
        }

        static Teacher[] Teacher()
        {
            Teacher[] arrTeachers = new Teacher[]
            {
                new Teacher(1,"Jeremy", "Crowley", 38,"Programming","Professor"),
                new Teacher(2,"Jane", "Levinsky", 33,"History", "Tarinee"),
                new Teacher(3,"Steffany", "Plum", 29 ,"Geography","Lector")
            };
            return arrTeachers;
        }
    }
}
