using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = 0;
            ArrayList list = new ArrayList();
            StreamReader stream = new StreamReader(@"D:\Test2.txt");
            string s = stream.ReadToEnd();
            string str = "";
            char[] ch = s.ToCharArray();
            for (int i = 0; i < ch.Length; i++)
            {
                if (char.IsDigit(ch[i]) || ch[i] == ',')
                {
                    str += ch[i];
                    if (!char.IsDigit(ch[i + 1]) && ch[i + 1] != ',')
                    {
                        list.Add(str);
                        str = "";
                    }
                }
            }
            foreach (string n in list)
            {
                a += double.Parse(n);
            }
            Console.WriteLine("Сумма чисел: " + a);
            Console.ReadKey();
        }
    }
}
