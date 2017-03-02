using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

class Person
{
    private byte age;
    private string first_name;
    private string last_name;

    public byte Age
    {
        get
        {
            return age;
        }
        set
        {
            age = value;
        }
    }

    public string First_name
    {
        get
        {
            return first_name;
        }
        set
        {
            first_name = value;
        }
    }

    public string Last_name
    {
        get
        {
            return last_name;
        }
        set
        {
            last_name = value;
        }
    }

    virtual public void Print()
    {
        Console.WriteLine("Имя: " + first_name);
        Console.WriteLine("Фамилия: " + last_name);
        Console.WriteLine("Возраст: " + age);
    }

    public override string ToString()
    {
        string str = "Имя: " + first_name + "; " + "Фамилия: " + last_name + "; " + "Возраст: " + age;
        return str;
    }
}

class Student : Person
{
    private string teacher;
    private string gruppa;
    private byte kurs;

    public string Teacher
    {
        get
        {
            return teacher;
        }
        set
        {
            teacher = value;
        }
    }

    public string Gruppa
    {
        get
        {
            return gruppa;
        }
        set
        {
            gruppa = value;
        }
    }

    public byte Kurs
    {
        get
        {
            return kurs;
        }
        set
        {
            kurs = value;
        }
    }

    public override void Print()
    {
        Console.WriteLine("Имя: " + base.First_name);
        Console.WriteLine("Фамилия: " + base.Last_name);
        Console.WriteLine("Возраст: " + base.Age);
        Console.WriteLine("Учитель: " + Teacher);
        Console.WriteLine("Группа: " + Gruppa);
    }
}

class Teacher : Person
{
    private List<Student> list_student = new List<Student>();

    public void AddStudent(Student student)
    {
        list_student.Add(student);
    }

    public bool RemoveStudent(Student student)
    {
        //var test=list_student.Select(x => x == student);
        if (list_student.Exists(x => x == student))
        {
            return list_student.Remove(student);
        }
        else
        {
            return false;
        }
    }

    public override void Print()
    {
        Console.WriteLine("Учитель: " + base.Last_name);
        Console.WriteLine("Возраст: " + base.Age);
        Console.WriteLine("Студенты: ");
        byte count = 0;
        foreach (var student in list_student)
        {
            Console.WriteLine(count + ")");
            student.Print();
            Console.WriteLine();
            count++;
        }
        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine();

    }
}
