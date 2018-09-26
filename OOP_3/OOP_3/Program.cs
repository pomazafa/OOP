using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle one = new Circle(15, 20, 30);
            Circle two = new Circle();
            Circle Three = new Circle(-50);
            double radius = one.Radius;
            Console.WriteLine("X = " + one.X + ", Y = " + one.Y + ", R = " + one.Radius);
            Console.WriteLine("Длина круга равна " + one.GetLength(one.Radius));
            Console.WriteLine("Площадь круга равна " + one.GetSquare(one.Radius));
            Console.WriteLine("Тип этого объекта: " + one.GetType());
            if(one.Equals(Three))
            {
                Console.WriteLine("Первый круг идентичен третьему!");
            }
            else
            {
                Console.WriteLine("Первый круг совсем не похож на третий!");
            }

            Circle[] arr = new Circle[3] { one, two, Three };

            Console.WriteLine(one.ToString());
            int k;
            int b;
            Console.WriteLine("Уравнение прямой выглядит как k*x + b. Введите k");
            k = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Введите b");
            b = Int32.Parse(Console.ReadLine());
            int c = 1;
            double maxSquare = one.GetSquare(one.Radius);
            double minSquare = one.GetSquare(one.Radius);
            int numberMax = 1;
            int numberMin = 1;
            foreach (Circle circle in arr)
                {
                if (circle.Y == k * circle.X + b)
                {
                    Console.WriteLine("Круг под номером " + c + " в массиве лежит на заданной линии");
                }
                if(circle.GetSquare(circle.Radius) > maxSquare)
                {
                    maxSquare = circle.GetSquare(circle.Radius);
                    numberMax = c;
                }
                if(circle.GetSquare(circle.Radius) < minSquare)
                {
                    minSquare = circle.GetSquare(circle.Radius);
                    numberMin = c;
                }
                c++;
            }
            Console.WriteLine("Круг с максимальной площадью в массиве под индексом " + numberMin + " и его площадь равна " + arr[numberMin - 1].GetSquare(arr[numberMin - 1].Radius));
            Console.WriteLine("Круг с максимальной площадью в массиве под индексом " + numberMax + " и его площадь равна " + arr[numberMax - 1].GetSquare(arr[numberMax - 1].Radius));
            var someTYPE = new { radius = 1, x = 2, y = 3 };
            Console.WriteLine(someTYPE);
            Console.ReadKey();
        }
    }

    partial class Circle
    {
        private static int count;
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }
        private int x;
        private int y;
        private double rad;
        private static double pi;
        private readonly int ID;
        private const int zero = 0;

    }



    partial class Circle
    {
        
        public double Radius
        {
            get
            {
                return rad;
            }
            set
            {
                if (rad < 0)
                {
                    Console.WriteLine("Неверное значение. Радиус не установлен");
                }
                else
                {
                    rad = value;
                }
            }
        }

        public Circle()
        {
            count++;
            X = 0;
            Y = 0;
            Radius = 0;
            ID = this.GetHashCode();
        }

        public Circle(int x, int y, double radius)
        {
            X = x;
            Y = y;
            Radius = radius;
            count++;
            ID = this.GetHashCode();
        }

       
        public Circle(double radius = 0)
        {
            X = 0;
            Y = 0;
            Radius = radius;
            ID = this.GetHashCode();
            count++;
        }

        static Circle()
        {
            pi = Math.PI;
            count = 0;
        }

        public static void GetInfo()
        {
            Console.WriteLine("Всего создано " + count + " экземпляров класса");
        }

        public double GetSquare(double radius)
        {
            return (pi * radius * radius);
        }

        public double GetLength(double radius)
        {
            return (2 * pi * radius);
        }

        private Circle(ref int x, ref int y)
        {
            X = x;
            Y = y;
            count++;
            ID = this.GetHashCode();
        }

        public Circle GetCircle(int x, int y)
        {
            int a = 0;
            return new Circle(ref a,ref  a);
        }

        public void GetRadius(out int radius)
        {
            radius = 0;
        }

        public override bool Equals(object obj)
        {
            Circle circle = (Circle)obj;
            return this.X == circle.X && this.Y == circle.Y && this.rad == circle.rad;
        }

        public override int GetHashCode()
        {
            int hash = 269;
            hash = Radius.GetHashCode();
            hash = (hash * 47) + x.GetHashCode();
            hash = (hash * 1111) + y.GetHashCode();
            return hash;
        }

        public override string ToString()
        {
            return ("Радиус = " + this.rad + ", х = " + this.X + ", у = " + this.Y);
        }
    }
}
