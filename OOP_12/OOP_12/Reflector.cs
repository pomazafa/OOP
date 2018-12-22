using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace OOP_12
{
    class Reflector
    {
        public static void GetMembers(Type t, StreamWriter sw)
        {
            sw.WriteLine("Full name = " + t.FullName);
            sw.WriteLine("\nMembers: ");
            foreach (MemberInfo mi in t.GetMembers())
            {
                sw.WriteLine(mi.Name);
            }
        }

        public static void GetPublicMethods(Type t)
        {
            Console.WriteLine("\nPublic methods: ");
            foreach (MethodInfo mi in t.GetMethods())
            {
                if(mi.IsPublic)
                    Console.WriteLine(mi.Name);
            }
        }

        public static void GetFieldsAndProperties(Type t)
        {
            Console.WriteLine("\nFields: ");
            foreach (FieldInfo fi in t.GetFields())
            {
                Console.WriteLine(fi.Name);
            }
            Console.WriteLine("\nProperties:");
            foreach (PropertyInfo pi in t.GetProperties())
            {
                Console.WriteLine(pi.Name);
            }
        }

        public static void GetInterfaces(Type t)
        {
            Console.WriteLine("\nInterfaces:");
            foreach(var ii in t.GetInterfaces())
            {
                Console.WriteLine(ii.Name);
            }
        }


        public static void GetMethodsWithParam(Type t1, Type t2)
        {

            Console.WriteLine("\nMethods with param " + t2 + ": ");
            foreach (MethodInfo mi in t1.GetMethods())
            {
                foreach (ParameterInfo pi in mi.GetParameters())
                {
                    if (pi.ParameterType == t2)
                    { Console.WriteLine(mi.Name); break; }
                }
            }
        }

        public void Runtimemethod(Date SS, string method)
        {
            FileStream fstream = new FileStream("C:\\Users\\Полина\\Desktop\\ООП\\labs\\OOP_12\\params.txt", FileMode.OpenOrCreate);
            StreamReader streamReader = new StreamReader(fstream);
            string par;
            par = streamReader.ReadLine();
            string par2 = streamReader.ReadLine();
            string[] parametrs = new string[2];
            parametrs[0] = par;
            parametrs[1] = par2;
            MethodInfo meth = SS.GetType().GetMethod(method);
            meth.Invoke(SS, parametrs);
        }
    }
}
