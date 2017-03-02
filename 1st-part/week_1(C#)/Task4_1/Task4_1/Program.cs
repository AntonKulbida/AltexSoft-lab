using System;
using System.Collections;
using System.IO;

namespace ConsoleApplication15
{
    class Student : IComparable
    {
        public string name;
        public int yearsOfBirth;
        public string address;
        public int nmbSchool;


        public override string ToString()
        {
            return String.Format(" Имя: {0}, Год рождения: {1}, Адресс: {2}, Номер школы: {3} ", name, yearsOfBirth, address, nmbSchool);
        }

        public int CompareTo(object obj)
        {
            Student b;
            b = (Student)obj;
            return yearsOfBirth.CompareTo(b.yearsOfBirth);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ArrayList people = new ArrayList();
            int k = 0;
            Console.WriteLine("Введите начальный список");
            while (k < 3)
            {
                Student a = new Student();
                Console.Write("Введите имя:");
                a.name = Console.ReadLine();
                Console.Write("Введите год рождения:");
                while (!Int32.TryParse(Console.ReadLine(), out a.yearsOfBirth))
                {
                    Console.Write("Введите год рождения: ");
                }
                // a.yearsOfBirth = int.Parse(Console.ReadLine());
                Console.Write("Введите адрес:");
                a.address = Console.ReadLine();
                Console.Write("Введите номер школы: ");
                while (!Int32.TryParse(Console.ReadLine(), out a.nmbSchool))
                {
                    Console.Write("Введите номер школы: ");
                }
                //   a.nmbSchool = int.Parse(Console.ReadLine());
                people.Add(a);
                k++;
            }
            Console.WriteLine("Информация о детях до сортировки: ");
            foreach (Student i in people)
            {
                Console.WriteLine(" " + i);
            }
            Console.WriteLine();
            people.Sort();
            Console.WriteLine("Информация о школьниках после сортировки: ");
            foreach (Student i in people)
            {
                Console.WriteLine(" " + i);
            }
            Console.ReadKey();
        }
    }
}