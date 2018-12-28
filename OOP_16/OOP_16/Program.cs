using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Collections.Concurrent;

namespace OOP_16
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[100000];
            int c = 0;
            Stopwatch stopWatch = new Stopwatch();
            Random random = new Random();
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;

            for (int k = 0; k < 100000; k++)
            {
                arr[k] = random.Next(0, 100);
            }
            Action<object> method = x =>
            {
                stopWatch.Start();
                Console.WriteLine("Id " + Task.CurrentId);
                for (int i = 0; i < 100000; i++)
                {
                    arr[i] *= 3;
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("Токен сработал");
                        return;
                    }

                }
                stopWatch.Stop();
                getTime(stopWatch);
                Console.WriteLine("Метод завершен");
            };

            void getTime(Stopwatch stw)
            {
                c++;
                Console.WriteLine("RunTime" + c + ' ' + stw.ElapsedTicks);
            }


            var task1 = new Task(method, TaskCreationOptions.LongRunning);
            task1.Start();

            if
                (!task1.IsCompleted) Console.WriteLine("Задача выполняется");
            else
                Console.WriteLine("Задача не выполняется");
            Console.WriteLine("Состояние " + task1.Status);

            task1.Wait();
            new Task(method, tokenSource.Token).Start();
            tokenSource.Cancel();


            Task<int> tsk2 = Task<int>.Factory.StartNew(First, 3);
            Task<int> tsk3 = Task<int>.Factory.StartNew(Second, 3);
            Task<int> tsk4 = Task<int>.Factory.StartNew(Third, 3);

            var continuation = Task.WhenAll(tsk2, tsk3, tsk4);

            for (int ctr = 0; ctr <= continuation.Result.Length - 1; ctr++)
            {
                Console.WriteLine(continuation.Result[ctr]);
            }
            Thread.Sleep(5000);

            Task<int> t1 = Task<int>.Factory.StartNew(First, 3);
            t1.GetAwaiter().GetResult();
            while (t1.GetAwaiter().IsCompleted)
            {
                if (t1.GetAwaiter().IsCompleted)
                {
                    Task<int> t2 = Task<int>.Factory.StartNew(First, t1.Result);
                    break;
                }
            }
            Stopwatch stopWatch1 = new Stopwatch();
            stopWatch1.Start();
            for (int i = 0; i < 1000000; i++)
            {
                int r = random.Next(0, 1000000);
            }
            stopWatch1.Stop();
            getTime(stopWatch1);


            Stopwatch stopWatch2 = new Stopwatch();
            stopWatch2.Start();
            Parallel.For(0, 1000000, (x) =>
            {
                int r = random.Next(0, 1000000);
            });
            stopWatch2.Stop();
            getTime(stopWatch2);


            Parallel.Invoke(() => First(2),
            () =>
            {
                Console.WriteLine("Выполняется задача {0}", Task.CurrentId);
                Thread.Sleep(3000);
            },
            () => Third(1000));

            smth8(0, 10);
            Thread.Sleep(2000);


            string[] str = new string[] { "Computer", "Phone", "Bottle", "Chair", "Tree" };
            BlockingCollection<string> bc = new BlockingCollection<string>();
            Task.Run(() => Add(0, 2000));
            Task.Run(() => Add(1, 3000));
            Task.Run(() => Add(2, 5000));
            Task.Run(() => Add(3, 7000));
            Task.Run(() => Add(4, 8000));
            Task.Run(() => TryTake(2500));
            Task.Run(() => TryTake(2600));
            Task.Run(() => TryTake(2700));
            Task.Run(() => TryTake(2800));
            Task.Run(() => TryTake(2900));
            Task.Run(() => TryTake(3000));
            Task.Run(() => TryTake(3100));
            Task.Run(() => TryTake(3200));
            Task.Run(() => TryTake(3300)).Wait();

            void TryTake(int t)
            {
                for (int i = 0; i < 5; i++)
                {
                    while (bc.Count != 0)
                    {
                        string[] a = bc.ToArray();
                        for (int z = 0; z < a.Length; z++)
                            foreach (string s in bc)
                                Console.WriteLine(s);
                        bc.Take();
                    }
                    Console.WriteLine();
                    Thread.Sleep(t);
                }
            }

            void Add(int i, int t)
            {
                for (int j = 0; j < 5; j++)
                {
                    bc.Add(str[i]);
                    foreach (string s in bc)
                        Console.WriteLine("Add " + s);
                    Console.WriteLine();
                    Thread.Sleep(t);
                }
            }
            
        }


        static async void smth8(int i, int j)
        {
            await Task.Run(() =>
            {
                for (int z = 10; z < 20; z++)
                {
                    Console.WriteLine(z);
                }

            });
            for (int z = i; z < j; z++)
            {
                Console.WriteLine(z);
            }
        }

            static int First(object t)
        {
            return (int)t * (int)t;
        }
        static int Second(object t)
        {
            return (int)t * (int)t * (int)t;
        }
        static int Third(object t)
        {
            return (int)t * (int)t * (int)t * (int)t;
        }
        
    }
}
