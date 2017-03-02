using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_3
{
    class Program
    {      
            static void Main(string[] args)
            {
                DirectoryInfo dir = new DirectoryInfo(@"D:\AltexSoft\Courses-5wave\1");
                Console.WriteLine("============Catalog list=============");
                foreach (var item in dir.GetDirectories())
                {
                    Console.WriteLine(item.Name);
                    Console.WriteLine("======Sublist======");
                    foreach (var it in item.GetFiles())

                        Console.WriteLine(it.Name);
                    Console.WriteLine();

                }
                Console.WriteLine("==============File list==============");
                foreach (var item in dir.GetFiles())
                {
                    Console.WriteLine(item.Name);
                }
                Console.ReadLine();
            }
        }
    }

