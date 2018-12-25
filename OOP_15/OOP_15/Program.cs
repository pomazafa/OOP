using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Reflection;
using System.Threading;
using System.IO;


namespace OOP_15
{
    class Program
    {
        public static object o = new object();
        static void Main(string[] args)
        {
            try
            {
                TimerCallback tm = new TimerCallback(Count);
                Timer timer = new Timer(tm, 0, 0, 5000);
                var allProcess = Process.GetProcesses();
                foreach (Process p in allProcess)
                {
                    Console.WriteLine("Id " + p.Id + ", Name " + p.ProcessName + ", Priority " + p.BasePriority + ", State " + p.Responding);
                    // Console.WriteLine("StartTime: " + p.StartTime);
                }

                AppDomain current = AppDomain.CurrentDomain;
                Console.WriteLine($"\nName of domain: {current.FriendlyName}");
                Console.WriteLine("Assemblies:");
                foreach (Assembly a in current.GetAssemblies())
                    Console.Write(a.FullName + " ");
                AppDomain newD = AppDomain.CreateDomain("New");
                newD.Load("OOP_15");
                AppDomain.Unload(newD);


                Thread thrd = new Thread(output)
                {
                    Name = "Output single numbers",
                    Priority = ThreadPriority.AboveNormal,
                    IsBackground = true,
                };
                Console.WriteLine();


                thrd.Start();
                Thread.Sleep(5000);
                thrd.Abort();

                Console.WriteLine();
                Thread th2 = new Thread(new ThreadStart(Th2));
                Thread th3 = new Thread(new ThreadStart(Th3));
                th2.Start();
                th3.Start();
                th3.Priority = ThreadPriority.Lowest;
                Thread.Sleep(5000);

                Thread th4 = new Thread(new ThreadStart(Th4));
                Thread th5 = new Thread(new ThreadStart(Th5));
                th4.Start();
                th5.Start();

            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.Message);
            }
        }

        private static void Count(object state)
        {
            Console.WriteLine("It's just timer...");
        }

        private static void output()
        {
            Console.WriteLine();
            Console.WriteLine($"Priority of thrd: { Thread.CurrentThread.Priority}, state: {Thread.CurrentThread.ThreadState}, name: {Thread.CurrentThread.Name}, ID: {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine("Input n:");
            int n = Convert.ToInt32(Console.ReadLine());
            using (StreamWriter sw = new StreamWriter("Single.txt", false, System.Text.Encoding.Default))
            {
                bool check = false;
                for (int i = 2; i < n; i++)
                {
                    int j = 2;
                    while (j < i)
                    {
                        if (i % j == 0)
                            check = true;
                        j++;
                    }
                    if (!check)
                    {
                        Console.WriteLine(i);
                        sw.WriteLine(i);
                    }
                    check = false;
                }
            }
        }

        public static void Th2()
        {
            lock (o)
            {

                using (StreamWriter st = new StreamWriter("numbers.txt", true, System.Text.Encoding.Default))
                {
                    for (int i = 1; i <= 10; i += 2)
                    {
                        Console.WriteLine(i);
                        st.WriteLine(i);

                        Thread.Sleep(500);
                    }
                }
            }
        }
        public static void Th3()
        {
            lock (o)
            {
                using (StreamWriter st = new StreamWriter("numbers.txt", true, System.Text.Encoding.Default))
                {
                    for (int i = 2; i <= 10; i += 2)
                    {
                        Console.WriteLine(i);
                        st.WriteLine(i);

                        Thread.Sleep(100);
                    }
                }
            }
        }

        public static void Th4()
        {

            Console.WriteLine();
            lock (o)
            {
                for (int i = 1; i <= 10; i += 2)
                {

                    Console.WriteLine(i);
                    using (StreamWriter sw = new StreamWriter("numbers.txt", true, System.Text.Encoding.Default))

                        sw.WriteLine(i);
                    Monitor.Pulse(o);

                    Monitor.Wait(o);

                   
                }
                Monitor.Pulse(o);
            }

        }
        public static void Th5()
        {
            lock (o)
            {
                for (int i = 2; i <= 10; i += 2)
                {

                    Console.WriteLine(i);
                    using (StreamWriter sw = new StreamWriter("numbers.txt", true, System.Text.Encoding.Default))
                        sw.WriteLine(i);

                    Monitor.Pulse(o);

                    Monitor.Wait(o);
                }
            }
            
        }
    }
}
