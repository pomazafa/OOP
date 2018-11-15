using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContrRab                                                              //Вариант 5
{
    public partial class Date                                                                                     //2
    {   
        int Day { get; set; }
        int Month { get; set; }
        int Year { get; set; }

        public Date(int d, int m, int y)
        {
            Day = d;
            Month = m;
            Year = y;
        }
    }

    public partial class Date
    {
        public override int GetHashCode()
        {
            return Day * 2 + Month * 99 + Year * 5;
        }
    }

    public interface ICan                                                                                           //3
    {
        void speak();
    }


    public class People : ICan
    {
        public void speak()
        {
            Console.WriteLine("Человек говорит");
        }
    }

    public static class Orator
    {
        public static void Checker(People p)
        {
            if (p is ICan)
            {
                p.speak();
            }
            else
            {
                Console.WriteLine("Интерфейс ICan не реализуется");
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1 задание");
            Console.WriteLine("А) Максимальное значение System.Single: " + System.Single.MaxValue);             //a
            string str = "abcdefghi";                                                                           //b
            string substr = str.Substring(4, 1);
            Console.WriteLine("Б) Исх. строка - " + str + ", подстрока c индекса 4, длиной 1 - " + substr);
            List<string> l1 = new List<string>();                                                               //c
            l1.Add(str);
            l1.Add(substr);
            Console.WriteLine("С) Вывод списка:");
            foreach(string s in l1)
                Console.WriteLine(s);

            Console.WriteLine();
            Console.WriteLine("2 задание");
            Date d1 = new Date(5, 12, 1999);                                                                    //2
            Date d2 = new Date(6, 12, 1999);

            if(d1.GetHashCode() > d2.GetHashCode())
            {
                Console.WriteLine("Хэш-код первой даты больше хэш-кода второй");
            }
            else
            {
                if(d1.GetHashCode() < d2.GetHashCode())
                {
                    Console.WriteLine("Хэш-код первой даты меньше хэш-кода второй");
                }
                else
                {
                    Console.WriteLine("Хэш-код первой даты равен хэш-коду второй. Похоже, даты совпали");
                }
            }

            Console.WriteLine();
            Console.WriteLine("3 задание");
            People p1 = new People();                                                                            //3
            Orator.Checker(p1);
        }
    }
}
