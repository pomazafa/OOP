using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContrRab2
{
    class Program
    {   
        
        static void Main(string[] args)
        {
            try
            {
                SuperCollection superC = new SuperCollection();
                superC.list_of_string.Add("Hello");
                superC.list_of_string.Add("World");
                superC.Add<Int32>(5);
                superC.Add<String>("sdjkfb");
                superC.Add<Double>(341232131.3636363636);

                foreach (string str in superC.list_of_string)
                {
                    Console.WriteLine(str);
                }

                //2
                Console.WriteLine();
                int[] arr_of_int = { 0, 2, -10, -22, 31, 12 };
                var b = arr_of_int.Where(p => p <= 0);
                Console.WriteLine(b.Count());

                Action deleg;
                Func<int> deleg2;
                Point one = new Point(10, 2, 22);
                Point two = new Point(2, -10, -77);

                deleg2 = one.GetSumXYZ;
                Console.WriteLine("Сумма x, y, z первой точки " + deleg2.Invoke());
                deleg2 = two.GetSumXYZ;
                Console.WriteLine("Сумма x, y, z второй точки " + deleg2.Invoke());

                deleg = one.Clear;
                deleg += two.Clear;
                deleg.Invoke();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
