using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2_2
{
    struct Student
    {
        public string Name;
        public string Surname;
        public int Age;
        public Student(string firstName, string lastName, int age)
        {
            this.Name = firstName;
            this.Surname = lastName;
            this.Age = age;
        }
        public override string ToString()
        {
            return String.Format("{0} {1} {2}", Name, Surname, Age);
        }
    }

    class StudentCmp : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            if (x.Age > y.Age)
            {
                return 1;
            }
            if (x.Age < y.Age)
            {
                return -1;
            }
            return 0;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student[] studentArray = new Student[]
            {
                new Student("Anton", "Kulbida", 23),
                new Student("Sveta", "Beliaeva", 25),
                new Student("Maxim", "Ivanov", 37), 
                new Student("Alex", "Filov", 10),
                new Student("Nicolai", "Elovich", 29),
                new Student("Oleg", "Ershov", 19),
                new Student("Gleb", "Logovin", 9)
            };

            Array.Sort(studentArray, new StudentCmp());
            Console.Write("Sorting students by name:\n");
            foreach (var student in studentArray.OrderBy(x => x.Name))
            {
                Console.WriteLine(student.ToString());
            }

            Console.WriteLine();
            Console.Write("Sorting students by age:\n");
            Array.Sort(studentArray, new StudentCmp());
            foreach (var student in studentArray)
            {
                Console.WriteLine(student.ToString());
            }
            Console.ReadLine();
        }
    }
}