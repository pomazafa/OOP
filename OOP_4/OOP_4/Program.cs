using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_4
{
    public static class MathOperation
    {
        public static int GetMax(Program.SetArray sa)
        {
            return sa.Set.Max();
        }
        public static int GetMin(Program.SetArray sa)
        {
            return sa.Set.Min();
        }
        public static int GetCount(Program.SetArray sa)
        {
            return sa.Set.Count();
        }
        public static int GetCipher(this string str)
        {
            return str.GetHashCode();
        }

        public static bool IsOrdered(this Program.SetArray sa)       //проверка на сортировку чисел по возрастанию
        {
            for (int i = 0; i < sa.Set.Count - 1; i++)
            {
                if (sa % i > sa % (i + 1))
                    return false;
            }
            return true;
        }
    }
    public class Program
    {
        public class Owner
        {
            public int Id;
            public string Name;
            public string Organization;
            public Owner()
            {
                Id = 0;
                Name = null;
                Organization = null;
            }
            public Owner(int id, string name, string organization)
            {
                Id = id;
                Name = name;
                Organization = organization;
            }
        }
        public class SetArray
        {
            public List<int> Set { get; set; }
            public int k;
            public Owner OwnerOfSet;
            public class Date
            {

                public int Year;
                public int Month;
                public int Day;
                public Date()
                {
                    Year = 0;
                    Month = 0;
                    Day = 0;
                }
                public Date(int year, int month, int day)
                {
                    Year = year;
                    Month = month;
                    Day = day;
                }
            }
            public SetArray()
            {
                Set = new List<int>();
                OwnerOfSet = new Owner();
            }
            public SetArray( int number, string Name, string organization, params int[] numbers)
            {
                Set = new List<int>();
                Set.AddRange(numbers);
                OwnerOfSet = new Owner(number, Name, organization);
            }
            public static SetArray operator + (SetArray setarr1, SetArray setarr2)  //перегрузка +, чтобы объёдинял множества
            {
                SetArray setarr3 = new SetArray();
                foreach (int x in setarr1.Set)
                {
                    setarr3.Set.Add(x);
                }
                foreach (int x in setarr2.Set)
                {
                    if (!setarr3.Set.Contains(x))
                    {
                        setarr3.Set.Add(x);
                    }
                }
                return setarr3;
            }
            public static SetArray operator ++ (SetArray sa)    //перегрузка ++, чтобы добавлял рандомное число в множество
            {
                Random num = new Random();
                sa.Set.Add(num.Next());
                return sa;
            }
            public static bool operator <= (SetArray sa1, SetArray sa2)     //перегрузка <= and >=, чтобы сравнивали мощность
            {
                if (sa1.Set.Capacity <= sa2.Set.Capacity)
                    return true;
                else
                    return false;
            }
            public static bool operator >=(SetArray sa1, SetArray sa2)  
            {
                if (sa1.Set.Capacity >= sa2.Set.Capacity)
                    return true;
                else
                    return false;
            }
            public static int operator %(SetArray sa, int num)      
            {
                return sa.Set[num];
            }
            public static implicit operator int(SetArray sa)
            {
                return sa.Set.Count;
            }
            public override string ToString()
            {
                return ("Id = " + this.OwnerOfSet.Id + ", Name = " + this.OwnerOfSet.Name + ", Organization = " + this.OwnerOfSet.Organization);
            }
        }

        static void Main(string[] args)
        {
            SetArray sa1 = new SetArray(1000001, "Oleg", "NPD", 1, 2, 3);
            SetArray sa2 = new SetArray(1111100, "Kate", "Kolesnik", 3, 4, 5);
            SetArray sa3 = new SetArray();
            sa3 = sa1 + sa2;
            sa3++;
            foreach (int item in sa3.Set)
            {
                Console.WriteLine(item);
            }
            if (sa1 <= sa3)
            {
                Console.WriteLine("Первое множество по мощности больше либо равно объединенному первому множеству со вторым");
            }
            else
            {
                Console.WriteLine("Первое множество по мощности меньше либо равно объединенному первому множеству со вторым");
            }
            Console.WriteLine(sa1 % 2 + " - элемент под индексом 2 в sa1");
            Console.WriteLine(1*sa1 + " - количество элементов в sa1");
            Console.WriteLine("Информация о sa1: " + sa1.ToString());
            SetArray.Date dt = new SetArray.Date(1999, 12, 5);
            Console.WriteLine("Max in sa1: " + MathOperation.GetMax(sa1));
            Console.WriteLine("Min in sa1: " + MathOperation.GetMin(sa1));
            Console.WriteLine("Count of sa1: " + MathOperation.GetCount(sa1));
            Console.WriteLine("abcs".GetCipher() + " - шифр строки \"abcs\"");
            Console.WriteLine("sa1 отсортирован по возрастанию - " + sa1.IsOrdered());
            Console.ReadKey();
        }
    }
}
