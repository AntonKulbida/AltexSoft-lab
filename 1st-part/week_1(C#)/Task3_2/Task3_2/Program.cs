using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_2
{
    class Program
    {
        static void Main()
        {
            double a, b;
            Random rnd = new Random();
            StreamWriter str = new StreamWriter(@"D:\Test1.txt");
            for (int i = 1; i <= 10; i++)
            {
                str.WriteLine(rnd.Next(20));
            }
            str.WriteLine();
            str.Close();
            StreamReader read = new StreamReader(@"D:\Test1.txt");
            for (int i = 1; i <= 10; i++)
            {
                a = double.Parse(read.ReadLine());
                b = Math.Pow(a, 2);
                Console.WriteLine("Число из файла: " + a + " Квадрат числа: " + b);
            }
            Console.ReadKey();
        }
    }
}