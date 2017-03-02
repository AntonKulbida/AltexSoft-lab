using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace catalog_diskov
{
    class students
    {
List<Student> students = new List<Student>();
            List<Teacher> teacher = new List<Teacher>();
 
            students.Add(new Student() { Age = 22,First_name = "Имя", Last_name = "Фамилия", Gruppa = "KSM-08-5", Kurs = 6, Teacher = "Фамилия1"});
            students.Add(new Student() { Age = 23, First_name = "Имя", Last_name = "Фамилия", Gruppa = "KSM-08-5", Kurs = 6, Teacher = "Фамилия2" });
            students.Add(new Student() { Age = 23, First_name = "Имя", Last_name = "Фамилия", Gruppa = "KSM-08-5", Kurs = 6, Teacher = "Фамилия3" });
            students.Add(new Student() { Age = 23, First_name = "Имя", Last_name = "Фамилия", Gruppa = "KSM-08-5", Kurs = 6, Teacher = "Фамилия1" });
 
            teacher.Add(new Teacher() { Age = 65, First_name = "Имя", Last_name = "Фамилия1" });
            teacher.Add(new Teacher() { Age = 63, First_name = "Имя", Last_name = "Фамилия2" });
            teacher.Add(new Teacher() { Age = 60, First_name = "Имя", Last_name = "Фамилия3" });
 
            for (int i = 0; i <= students.Count - 1; i++)
            {
                for (int j = 0; j <= teacher.Count - 1; j++)
                {
                    if (teacher[j].Last_name == students[i].Teacher)
                    {
                        teacher[j].AddStudent(students[i]);
                    }
                }
            }
            foreach (var teacher1 in teacher)
            {
                teacher1.Print();
            }
            Console.Read();
