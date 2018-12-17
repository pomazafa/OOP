using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace OOP_12
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                StreamWriter sw = new StreamWriter(@"C:\Users\Полина\Desktop\ООП\labs\OOP_12\eee.txt");
                Type t = typeof(Date);
                Type t2 = typeof(int);
                Reflector.GetMembers(t, sw);
                sw.Close();

                Reflector.GetPublicMethods(t);
                Reflector.GetFieldsAndProperties(t);
                Reflector.GetInterfaces(t);
                Reflector.GetMethodsWithParam(t, t2);
                Date d1 = new Date(15, 22, 1922);
                Reflector r1 = new Reflector();
                r1.Runtimemethod(d1, "Test");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
