using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_9
{
    class Program
    {

        public class Equipment
        {
            public bool broken = false;
            public bool on = false;
        }

        public class TV : Equipment
        {

            public void OnUpgrade()
            {
                if (!broken)
                {
                    if (!on)
                        Console.WriteLine("Телевизор улучшен!");
                    else
                        Console.WriteLine("Телевизор в сети, сейчас его невозможно улучшить.");
                }
            }

            public void OnTurnOn()
            {
                if (!broken)
                {
                    if (!on)
                    {
                        Console.WriteLine("Телевизор включен.");
                        on = true;
                    }
                    else
                        Console.WriteLine("Телевизор уже был включен, включение невозможно.");
                }
            }
        }
        public class Radio : Equipment
        {
            public void OnUpgrade()
            {
                if (!broken)
                {
                    if(!on)
                        Console.WriteLine("Радио улучшено!");
                    else
                        Console.WriteLine("Радио включено в сеть, сейчас его невозможно улучшить.");
                }
            }

            public void OnTurnOn()
            {
                if(!broken)
                {
                    if (!on)
                    {
                        Console.WriteLine("Радио включено.");
                        on = true;
                    }
                    else
                        Console.WriteLine("Невозможно включить уже включенное радио.");
                }
            }
        }

        public class Laptop : Equipment
        {
            public void OnUpgrade()
            {
                if (!broken)
                {
                    if (!on)
                        Console.WriteLine("Лэптоп улучшен!");
                    else
                        Console.WriteLine("В данный момент лэптоп не улучшить, он влючен в сеть!");
                }
            }
            public void OnTurnOn()
            {
                if (!broken)
                {
                    Console.WriteLine("Введите требуемое значение напряжения: ");
                    Console.WriteLine("Лэптоп включается под напряжением " + Convert.ToInt32(Console.ReadLine()));
                    on = true;
                }
                else
                    Console.WriteLine("Кажется, лэптоп сломан.");
            }
        }

        public class Boss
        {
            public event D Upgrade;
            public event D TurnOn;
            public void CommandUpgrade()
            {
                if ((Upgrade != null) && !brokenMen)
                    Upgrade();
            }
            public void CommandTurnOn()
            {
                if ((TurnOn != null) && !brokenMen)
                    TurnOn();
            }
            public bool brokenMen = false;
        }

        public delegate void D();

        public class StringOperation
        {
            public static void WriteString(string str)
            {
                Console.WriteLine(str);
            }
            public static string DeleteK(string str)
            {
                string st1 = "";
                string[] strArray = str.Split('K');
                foreach (string s in strArray)
                    st1 += s;
                str = st1;
                return str;
            }
            public static string AddHello(string str)
            {
                str = "Hello! " + str;
                return str;
            }
            public static string AddEnd1(string str)
            {
                str = str + " From England with love.";
                return str;
            }
            public static string AddEnd2(string str)
            {
                str = str + "Bye!";
                return str;
            }
        }


        public static string UpgradeString(string str)
        {
            Func<string, string> DelegAll;
            Action<string> Act;

            Act = StringOperation.WriteString;
            Act(str);
            DelegAll = StringOperation.DeleteK;
            str = DelegAll(str);
            Act(str);
            DelegAll = StringOperation.AddHello;
            str = DelegAll(str);
            Act(str);
            DelegAll = StringOperation.AddEnd1;
            str = DelegAll(str);
            Act(str);
            DelegAll = StringOperation.AddEnd2;
            string res = DelegAll(str);
            return res;
        }

        static void Main()
        {
            try
            {
                Boss hero = new Boss();
                Laptop L1 = new Laptop();
                Radio R1 = new Radio();
                TV T1 = new TV();

                L1.broken = true;
                hero.TurnOn += L1.OnTurnOn;
                hero.TurnOn += R1.OnTurnOn;
                hero.TurnOn += T1.OnTurnOn;

                hero.CommandTurnOn();
                hero.brokenMen = true;
                hero.Upgrade += T1.OnUpgrade;

                hero.CommandUpgrade();


                Console.WriteLine();

                string str = "I'm mr. DavKidson, jusKt Ksent you an e-mail. I hope, you will see it.";
                string res = UpgradeString(str);
                Console.WriteLine(res);
                Console.ReadLine();
            }
            catch(System.FormatException)
            {
                Console.WriteLine("Исключение! Неверный формат.");
            }
        }
    }
}   