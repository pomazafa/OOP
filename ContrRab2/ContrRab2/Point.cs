using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContrRab2
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Point(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }


        public void Clear()
        {
            Console.WriteLine("Удаление координат точки");
            X = 0;
            Y = 0;
            Z = 0;
        }

        public int GetSumXYZ()
        {
            return X + Y + Z;
        }
    }
}
