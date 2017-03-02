using System;
using System.Linq;

namespace Task_5
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte Age { get; set; }

        public Person()
        { }

        public Person(string name, string surname, byte age)
        {
            this.Name = name;
            this.Surname = surname;
            this.Age = age;
        }

        public virtual void Print()
        {
            Console.WriteLine("Name: {0}\nSurname: {1}\nAge: {2}", Name, Surname, Age);
        }

        public override string ToString()
        {
            // return String.Format("Overrided ToString() Method from {0}", this.GetType().Name);
            return String.Format("\nName: {0}\nSurname: {1}\nAge: {2}", Name, Surname, Age);
        }

        public static void RndPerson(Person[] personArr)
        {

        }

    }
}
