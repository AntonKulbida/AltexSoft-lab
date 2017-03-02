using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task_5
{
    static class TaskHelper
    {
        public static void TeacherStudents(Teacher[] teachers, Student[] students)
        {
            int count = 0;
            foreach (var teacher in teachers)
            {
                Color(String.Format("\n{0} teacher - {1} {2} ", teacher.Subject, teacher.Surname, teacher.Name), ConsoleColor.Blue);
                foreach (var student in students)
                {
                    if (student.TeacherID == teacher.ID)
                    {
                        Console.WriteLine(student.ToString());
                        teacher.StudentsOfTeacher.Add(student);
                        count++;
                    }
                }
                if (count == 0)
                    Console.WriteLine("No students");
                count = 0;
            }
        }


        #region ToString()

        public static void OverridedToString(Person[] person, Teacher[] teacher, Student[] student)
        {
            Color("\nOverride ToString() method", ConsoleColor.Blue);
            for (int i = 0; i < 1; i++)
            {
                Console.WriteLine(person[i].ToString());
                Console.WriteLine(teacher[i].ToString());
                Console.WriteLine(student[i].ToString());
            }
        }
        #endregion

        #region GetInnerTypes

        public static void GetInnetTypes<T>(T[] obj) where T : class
        {
            var typeObj = obj.GetType().Name;

            int countP = 0;
            int countS = 0;
            int countT = 0;
            Student st;
            List<Student> tempSt = new List<Student>();

            foreach (var item in obj)
            {
                if (item != null)
                {
                    if (item is Person)
                        countP++;
                    if (item as Student != null)
                    {
                        countS++;
                        st = item as Student;
                        if (st.Course + 1 <= 5)
                            st.Course++;
                        else st.Course = 0;
                        tempSt.Add(st);
                    }
                    if (item.GetType().Name == new Teacher().GetType().Name)
                        countT++;
                }
            }
            Console.WriteLine("There are {0} Persons; {1} Students; {2} Teachers\n", countP, countS, countT);
            if (tempSt.Count > 0)
            {
                Color("Students go to next course", ConsoleColor.Blue);
                foreach (var student in tempSt)
                    student.Print();
            }
        }

        #endregion


        public static void Color(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

}
