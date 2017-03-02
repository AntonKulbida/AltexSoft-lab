﻿using System;
using System.Collections;
using System.Linq;
namespace Task2
{
    internal static class Task
    {
        public static void RunTask()
        {
            /*
              Дана целочисленная последовательность, содержащая как положительные, так и отрицательные числа. 
              Вывести ее первый положительный элемент и последний отрицательный элемент.
             */
            var intArray1 = new int[10] { -5, -7, 10, 1, -9, 9, -15, 11, 0, 5 };
            var result1 = intArray1.Where(a => a > 0).Take(1).Union(intArray1.Reverse().Where(a => a < 0).Take(1));
            Console.WriteLine("\nLinqBegin1");
            Input(result1);
   
            /*
             Дан символ С и строковая последовательность A. Найти количество элементов A, которые содержат более одного символа 
             и при этом начинаются и оканчиваются символом C.
             */
            var ch5 = 'a';
            var stringArray5 = new string[8] { "asdfg", "aasda", "qwert", "3aa", "9abcd", "a5a", "ccccccc", "a" };
            var result5 = stringArray5.Count(s => s.Length > 1 && s[0] == ch5 && s[s.Count() - 1] == ch5);
            Console.WriteLine("\nLinqBegin5");
            Console.WriteLine(result5);
            /*
             Дана строковая последовательность. Найти сумму длин всех строк, входящих в данную последовательность. 
             */
            var stringArray6 = new string[8] { "asdfg", "aasda", "qwert", "3aa", "9abcd", "a5a", "ccccccc", "a" };
            var result6 = 0;
            result6 = stringArray6.Select(s => s.Length).Sum();
            Console.WriteLine("\nLinqBegin6");
            Console.WriteLine(result6);

            /*
             Дана целочисленная последовательность. Используя метод Aggregate, найти произведение последних цифр всех элементов последовательности. 
             * Чтобы избежать целочисленного переполнения, при вычислении произведения использовать вещественный числовой тип.
             */
            var intArray12 = new int[10] { -5462, -7562451, 12562, 25622, -2561, 9542, -124561, 12562, 255, 525251 };
            var result12 = intArray12.Aggregate(1, (x, y) => x * int.Parse(y.ToString().Substring(y.ToString().Count() - 1, 1)));
            Console.WriteLine("\nLinqBegin12");
            Console.WriteLine(result12);
            /*
             Дано целое число N (> 0). Используя методы Range и Sum, найти сумму 1 + (1/2) + … + (1/N) (как вещест-венное число).
             */
            var i13 = 5;
            var result13 = Enumerable.Range(1, i13).Sum(a => (double)1 / a);
            Console.WriteLine("\nLinqBegin13");
            Console.WriteLine(result13);
            /*
             Дано целое число N (0 ≤ N ≤ 15). Используя методы Range и Aggregate, найти факториал числа N: N! = 1·2·…·N при N ≥ 1; 0! = 1. 
             Чтобы избежать целочислен-ного переполнения, при вычислении факториала использовать вещественный числовой тип.
             */
            var i15 = 5;
            var result15 = Enumerable.Range(1, i15).Aggregate(1, (s, i) => s * i);
            Console.WriteLine("\nLinqBegin15");
            Console.WriteLine(result15);
            /*
             Дана целочисленная последовательность. Извлечь из нее все четные отрицательные числа, поменяв порядок извлеченных чисел на обратный.
             */
            var intArray18 = new int[10] { -5, -8, 10, 0, -9, -6, -15, 17, 0, -2 };
            var result18 = intArray18.Where(i => i % 2 == 0 && i < 0).Reverse();
            Console.WriteLine("\nLinqBegin18");
            Input(result18);
            /*
              Дана цифра D (целое однозначное число) и целочисленная последовательность A. Извлечь из A все различные положительные числа, 
              оканчивающиеся цифрой D (в исходном порядке). При наличии повторяющихся элементов удалять все их вхождения, кроме последних.
              Указание. Последовательно применить методы Reverse, Distinct, Reverse.
             */
            var d19 = 5;
            var intArray19 = new int[12] { -5, -8, 25, 0, -9, -6, -15, 17, 5, -2, 25, 5 };
            var result19 = intArray19.Where(i => i > 0 && int.Parse(i.ToString().Substring(i.ToString().Count() - 1, 1)) == d19).Reverse().Distinct().Reverse();
            Console.WriteLine("\nLinqBegin19");
            Input(result19);
            /*
             Дано целое число K (> 0) и строковая последовательность A. Строки последовательности содержат только цифры и заглавные буквы латинского алфавита. 
             Извлечь из A все строки длины K, оканчивающиеся цифрой, отсортировав их в лексикографическом порядке по возрастанию.
             */
            var k22 = 5;
            var a22 = new string[5] { "F1f89", "4f3dd", "Affffff", "Afff8", "Bfff3" };
            var result22_ = a22.Where(a => a.Length == k22 && a.Substring(a.Count() - 1, 1).Intersect("0123456789").Any()).OrderBy(s => s);
            Console.WriteLine("\nLinqBegin22");
            Input(result22_);
            /*
              Дано целое число D и целочисленная последовательность A. 
             Начиная с первого элемента A, большего D, извлечь из A все нечетные положительные числа, поменяв порядок извлеченных чисел на обратный.
             */
            var d27 = 10;
            var intArray27 = new int[15] { 0, 7, 5, -5, -8, 25, 0, -9, -6, -15, 17, 5, -2, 25, 5 };
            var result27 = intArray27.SkipWhile(i => i < d27).Where(i => i > 0 && i % 2 != 0).Reverse();
            Console.WriteLine("\nLinqBegin27");
            Input(result27);
            /*
             Дана последовательность непустых строк A. Получить последовательность символов, каждый элемент которой является начальным символом 
             соответствующей строки из A. Порядок символов должен быть обратным по отношению к порядку элементов исходной последовательности.
             */
            var a32 = new string[8] { "asdfg", "aasda", "qwert", "jaa", "bcd", "a5a", "ccccccc", "a" };
            var result32_ = a32.Select(a => a.First()).Reverse();
            Console.WriteLine("\nLinqBegin32");
            Input(result32_);

   
        }
        public static void Input(IEnumerable data)
        {
            if (data == null)
                return;
            var i = 1;
            foreach (var d in data)
            {
                Console.WriteLine("{0}: {1}", i++, d);
            }
        }
    }
}