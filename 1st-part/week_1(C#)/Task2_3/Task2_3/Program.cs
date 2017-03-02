using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int arrSize = 0;
            Console.Write("Write lenght of array: ");
            while (!Int32.TryParse(Console.ReadLine(), out arrSize))
            {
                Console.Write("Try again!\nWrite lenght of array: ");
            }

            int[] arrN = new int[arrSize];

            Random r = new Random();
            Console.Write("No sort: ");

            for (int i = 0; i < arrSize; i++)
            {
                arrN[i] = r.Next(-500, 500);
                Console.Write(arrN[i] + " ");
            }

            Console.WriteLine();
            Array.Sort(arrN);

            Console.Write("Sort: ");
            for (int i = 0; i < arrSize; i++)
                Console.Write(arrN[i] + " ");

            Console.ReadKey();
        }
    }
}