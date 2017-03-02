using System;
using System.Collections.Generic;

namespace Task4_4
{
    class Auto
    {
        public string CarName { set; get; }
        public string NmbCar { get; set; }
        public string FioOwner { get; set; }
        public int YearBuy { get; set; }
        public double Run { get; set; }
        public int ID { get; set; }


        public Auto() { }
        public Auto(string CarName, string NmbCar, string FioOwner, int YearBuy, double Run, int ID)
        {
            this.CarName = CarName;
            this.NmbCar = NmbCar;
            this.FioOwner = FioOwner;
            this.YearBuy = YearBuy;
            this.Run = Run;
            this.ID = ID;
        }

        public override string ToString()
        {
            return String.Format("{5} Марка:  {0}\tНомер автомобиля: {1}\t Bладелeц: {2}\t Куплена в {3}\t  Провег в км: {4}",
                this.CarName, this.NmbCar, this.FioOwner, this.YearBuy, this.Run, this.ID);
        }
    }

    class AutoList<T> : IComparer<T>
        where T : Auto
    {

        public int Compare(T x, T y)
        {
            if (x.Run < y.Run)
                return 1;
            if (x.Run > y.Run)
                return -1;
            else return 0;
        }
    }

    class Program
    {
        static void Main()
        {
            AutoList<Auto> cp = new AutoList<Auto>();
            List<Auto> listAuto = new List<Auto>();

            listAuto.Add(new Auto("BMW M5", "BI1094", "Кульбида", 2010, 7490, 1));
            listAuto.Add(new Auto("Subaru", "BI1904", "Иваненко", 2013, 5000, 2));
            listAuto.Add(new Auto("Mercedes", "BI1854", "Сёмшкин", 2014, 4592, 3));
            listAuto.Add(new Auto("Audi A8", "BI8550", "Стапанчин", 2009, 10450, 4));
            listAuto.Add(new Auto("RR Sport", "BI3223", "Ковинь", 2011, 11007, 5));

            Console.WriteLine("Исходный каталог автомобильных ведомостей: \n");
            Console.WindowWidth = 130;
            foreach (Auto a in listAuto)
                Console.WriteLine(a);

            Console.WriteLine("\nТеперь автомобили отсортированны по пробегу: \n");
            listAuto.Sort(cp);
            foreach (Auto a in listAuto)
                Console.WriteLine(a);

            Console.ReadLine();
        }
    }
}