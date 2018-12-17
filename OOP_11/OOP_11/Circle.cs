using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_11
{
    class Circle
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

        public double Radius
        {
            get
            {
                return rad;
            }
            set
            {
                if (value < 0)
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
            int a = 5;
            return new Circle(ref a, ref a);
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
