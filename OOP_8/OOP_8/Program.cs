using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_8
{
    public class QuestionException : Exception
    {
        public QuestionException(string message)
        : base(message)
        { }
    }

    public sealed class Question
    {
        public string Text
        {
            get { return text; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new QuestionException("Передана пустая строка! Вопрос не задан.");
                }
                else
                {
                    text = value;
                }
            }
        }

        private string text;

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return Text;
        }
    }
    interface IDo<T>
    {
        void add(T element);
        void delete(T element);
        void show();
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
        public class CollectionType<T> : IDo<T> where T : new()
        {
            public List<T> Set { get; set; }
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

            public void add(T element)
            {
                Set.Add(element);
            }
            public void delete( T element)
            {
                Set.Remove(element);
            }
            public void show()
            {
                Console.WriteLine("Id = " + OwnerOfSet.Id + ", Name = " + OwnerOfSet.Name + ", Organization = " + OwnerOfSet.Organization);
                Console.WriteLine("Элементы:");
                foreach (var t in Set)
                    Console.WriteLine(t);
            }

            public CollectionType()
            {
                Set = new List<T>();
                OwnerOfSet = new Owner();
            }
            public CollectionType(int number, string Name, string organization, params T[] items)
            {
                Set = new List<T>();
                Set.AddRange(items);
                OwnerOfSet = new Owner(number, Name, organization);
            }
            public static List<T> operator +(CollectionType<T> setarr1, CollectionType<T> setarr2)  //перегрузка +, чтобы объёдинял множества
            {
                CollectionType<T> setarr3 = new CollectionType<T>();
                foreach (var x in setarr1.Set)
                {
                    setarr3.Set.Add(x);
                }
                foreach (var x in setarr2.Set)
                {
                    if (!setarr3.Set.Contains(x))
                    {
                        setarr3.Set.Add(x);
                    }
                }
                return setarr3.Set;
            }

            public static bool operator <=(CollectionType<T> sa1, CollectionType<T> sa2)     //перегрузка <= and >=, чтобы сравнивали мощность
            {
                if (sa1.Set.Capacity <= sa2.Set.Capacity)
                    return true;
                else
                    return false;
            }
            public static bool operator >=(CollectionType<T> sa1, CollectionType<T> sa2)
            {
                if (sa1.Set.Capacity >= sa2.Set.Capacity)
                    return true;
                else
                    return false;
            }
            public static T operator %(CollectionType<T> sa, int num)
            {
                return sa.Set[num];
            }
            public static implicit operator int(CollectionType<T> sa)
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

            try
            {
                CollectionType<int> sa1 = new CollectionType<int>(1000001, "Oleg", "NPD", 1, 2, 3);
                CollectionType<int> sa2 = new CollectionType<int>(1111100, "Kate", "Kolesnik", 3, 4, 5);
                CollectionType<int> sa3 = new CollectionType<int>();
                CollectionType<double> sa4 = new CollectionType<double>(1000111, "Nick", "Hyper", 1234.123333333333333333333, 412374681.123);
                CollectionType<double> sa5 = new CollectionType<double>(1001011, "Jim", "Kelmi",321.1111111111111, 1.2);
                CollectionType<char> sa8 = new CollectionType<char>(1001011, "Jim", "Kelmi", 'a', 'e');
                CollectionType<float> sa6 = new CollectionType<float>(1101101, "John", "Klimbing", (float)2.2, 1212, 9, (float)3189.31, 213);
                sa3.Set = sa1 + sa2;
                foreach (var item in sa3.Set)
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
                Console.WriteLine(1 * sa1 + " - количество элементов в sa1");
                Console.WriteLine("Информация о sa1: " + sa1.ToString());
                sa5.Set = sa5 + sa4;
                Console.WriteLine("Элементы sa4 + sa5 :");
                foreach (var item in sa5.Set)
                {
                    Console.WriteLine(item);
                }

                sa4.add(44444);
                sa5.delete(1.2);
                Console.WriteLine("Информация о sa5:");
                sa5.show();
                Console.WriteLine("Информация о sa6:");
                sa6.show();

                Question q1 = new Question();
                q1.Text = "Oh, it's a question";

                CollectionType<Question> sa7 = new CollectionType<Question>(1110000, "Katrin", "Zippo", q1);
                Console.WriteLine("Информация о sa7:");
                sa7.show();

            }

            catch (QuestionException e)
            {
                Console.WriteLine(e);
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            finally
            {
                Console.WriteLine("Программа завершена!");
            }
            Console.ReadKey();
        }
    }
}
