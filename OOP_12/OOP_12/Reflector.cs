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

            /*foreach (Type iType in t.GetInterfaces())
            {
                sw.WriteLine(iType.Name);
            }
            sw.WriteLine("\nFields: ");
            foreach (FieldInfo fi in t.GetFields())
            {
                sw.WriteLine(fi.Name);
            }
            sw.WriteLine("\nProperties:");
            foreach(PropertyInfo pi in t.GetProperties())
            {
               sw.WriteLine(pi.Name);
            }
            sw.WriteLine("\nMethods: ");
            foreach (MethodInfo mi in t.GetMethods())
            {
                sw.WriteLine(mi.Name);
            }
            sw.WriteLine("\nConstructors with parameters: ");
            foreach (ConstructorInfo ci in t.GetConstructors())
            {
                
                foreach(ParameterInfo pi in ci.GetParameters())
                    sw.Write(pi.ParameterType + " " + pi.Name + "     ");
                sw.WriteLine();
            }
            sw.WriteLine("\nEvents: ");
            foreach (EventInfo ei in t.GetEvents())
            {
                sw.WriteLine(ei.Name);
            }*/
            sw.WriteLine("\nMembers: ");
            foreach (MemberInfo mi in t.GetMembers())
            {
                sw.WriteLine(mi.Name);
            }
        }

        public static void GetPublicMethods(Type t)
        {
            Console.WriteLine("Public methods: ");
            foreach (MethodInfo mi in t.GetMethods())
            {
                if(mi.IsPublic)
                    Console.WriteLine(mi.Name);
            }
        }

        public static void GetFieldsAndProperties(Type t)
        {
            Console.WriteLine("Fields: ");
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
            Console.WriteLine("Interfaces:");
            foreach(var ii in t.GetInterfaces())
            {
                Console.WriteLine(ii.Name);
            }
        }


        public static void GetMethodsWithParam(Type t1, Type t2)
        {

            Console.WriteLine("Methods with param " + t2 + ": ");
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
            par = streamReader.ReadToEnd();
            string[] parametrs = new string[1];
            parametrs[0] = par;
            MethodInfo meth = SS.GetType().GetMethod(method);
            meth.Invoke(SS, parametrs);
        }
    }
}
