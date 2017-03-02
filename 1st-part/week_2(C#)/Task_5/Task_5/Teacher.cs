using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Task_5
{
    public class Teacher : Person
    {
        public int ID { get; set; }
        public string Subject { get; set; }
        public string Rank { get; set; }

        public List<Student> StudentsOfTeacher = new List<Student>();

        public Teacher()
        {

        }
        public Teacher(int id, string name, string surname, byte age, string subject, string rank)
            : base(name, surname, age)
        {
            this.Subject = subject;
            this.Rank = rank;
            this.ID = id;
        }

        public override void Print()
        {
            Console.WriteLine("Name: {0}\nSurname: {1}\nAge: {2}\nSubject: {3}\nRank: {4}\n", Name, Surname, Age, Subject, Rank);
        }

        public override string ToString()
        {
            return String.Format(base.ToString() + "\nSubject: {0}\nRank: {1}", Subject, Rank);
        }

        public static void RandomTeacher(Teacher[] teacherArr)
        {
            //   Random rand = new Random();

        }
    }
}
