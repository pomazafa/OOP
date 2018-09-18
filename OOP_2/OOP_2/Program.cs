using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Определите переменные всех возможных примитивных типов С#  и проинициализируйте их. 
            bool firstBool;
            firstBool = true;
            byte firstByte;
            firstByte = 255;
            sbyte firstSbyte;
            firstSbyte = -101;
            short firstShort;
            firstShort = 11000;
            ushort firstUshort;
            firstUshort = 0;
            int firstInt;
            firstInt = 23123;
            uint firstUint;
            firstUint = 0;
            long firstLong;
            firstLong = 231;
            ulong firstUlong;
            firstUlong = 0;
            float firstFloat;
            firstFloat = 12.0F;
            double firstDouble;
            firstDouble = 123213123123.123213312;
            decimal firstDecimal;
            firstDecimal = 213154526456234.3423412344433M;
            char firstChar;
            firstChar = 'A';
            string firstString;
            firstString = "dfjsd";
            object firstObject;
            firstObject = 12.99;

            //Выполните 5 операций явного и 5 неявного приведения. 
            firstObject = firstString;
            firstDouble = firstFloat;
            firstFloat = firstInt;
            firstInt = firstShort;
            firstLong = firstShort;
            firstInt = (int)firstLong;
            firstShort = (short)firstLong;
            firstLong = (long)firstInt;
            firstSbyte = (sbyte)firstByte;
            firstDecimal = (decimal)firstDouble;

            //Выполните упаковку и распаковку значимых типов. 
            firstObject = firstInt;
            int secondInt = (int)firstObject;
            firstObject = firstUlong;
            ulong secondUlong = (ulong)firstObject;

            //Продемонстрируйте работу с неявно типизированной переменной. 
            var abc = "abc";
            Console.WriteLine(abc);

            //Продемонстрируйте пример работы с Nullable переменной.
            short? secondShort = null;
            if (secondShort == null)
            {
                Console.WriteLine("Nullable переменная равна null");
            }

            //Строки. Объявите строковые литералы. Сравните их. 
            String firstPath = "first";
            String secondPath = "first";
            if (secondPath == firstPath)
            {
                Console.WriteLine("Литералы одинаковые");
            }

            //Создайте три строки на основе String. Выполните: сцепление, копирование, выделение подстроки, 
            //разделение строки на слова, вставки подстроки в заданную позицию, удаление заданной подстроки. 
            string secondString = new string('a', 10);
            string thirdString = new string(firstChar, 5);
            char[] arrayChar = { 'a', ' ', 'c', ' ', 'd', ' ', 'f' };
            string fourString = new string(arrayChar);
            firstString = String.Concat(secondString, thirdString); //cцепление
            firstString = String.Copy(secondString);
            firstString = fourString.Substring(1);
            string[] arrayString = fourString.Split(' ');
            for (int i = 0; i < arrayString.Length; i++)
            {
                Console.WriteLine(arrayString[i]);
            }
            firstString = firstString.Insert(3, "inserted");
            Console.WriteLine(firstString);
            firstString = firstString.Remove(6);
            Console.WriteLine(firstString);

            //Создайте пустую и null строку. Продемонстрируйте что можно выполнить с такими строками 
            string fifthString = "";
            string sixthString = null;
            fifthString = fifthString.Insert(0, "inserted fifth string");
            fifthString = String.Concat(sixthString, fifthString);
            Console.WriteLine(fifthString);
            if (fifthString == sixthString)
            {
                Console.WriteLine("Строка-то равна null!");
            }

            //Создайте строку на основе StringBuilder. Удалите определенные позиции и добавьте новые символы в начало и конец строки. 
            StringBuilder firstStrB = new StringBuilder("oh no", 30);
            firstStrB.Remove(1, 1);
            Console.WriteLine(firstStrB);
            firstStrB.Append(new char[] { '0', 'o' });
            Console.WriteLine(firstStrB);
            firstStrB.Insert(0, new char[] { 'o', '0' });
            Console.WriteLine(firstStrB);

            //Массивы. Создайте целый двумерный массив и выведите его на консоль в отформатированном виде (матрица).  

            int[,] mass = { { 5, 6, 7 }, { 4, 5, 6 }, { 3, 4, 5 } } ;
            for (int i = 0; i < mass.GetLength(0); i++)
            {
                for (int j = 0; j < mass.GetLength(1); j++)
                {
                    Console.Write(mass[i, j] + " ");
                }
                Console.WriteLine();
            }
            //Создайте одномерный массив строк. Выведите на консоль его содержимое, длину массива. Поменяйте произвольный 
            //элемент (пользователь определяет позицию и значение). 
            string[] arrayOfString = { "abc", "def", "kjfsfj" };
            for (int i = 0; i < arrayOfString.Length; i++)
            {
                Console.WriteLine(i + " - " + arrayOfString[i]);
            }
            Console.WriteLine("Длина массива = " + arrayOfString.Length);
            Console.WriteLine("Введите число от 0 до " + (arrayOfString.Length - 1));
            int k = int.Parse(Console.ReadLine());
            if(k < 0 || k > arrayOfString.Length)
            {
                Console.WriteLine("Введено недопустимое значение");
            }
            else
            {
                Console.WriteLine("Введите строку, на которую хотите заменить предыдущее значение");
                arrayOfString[k] = Console.ReadLine();
            }
            Console.WriteLine("Получившийся массив:");
            for (int i = 0; i < arrayOfString.Length; i++)
            {
                Console.WriteLine(i + " - " + arrayOfString[i]);
            }

            //Создайте ступечатый (не выровненный) массив вещественных чисел с 3-мя строками, в каждой из которых 2, 3 и 4 столбцов 
            //соответственно. Значения массива введите с консоли. 
            float[][] arrayOfFloat = new float[3][];
            arrayOfFloat[0] = new float[2];
            arrayOfFloat[1] = new float[3];
            arrayOfFloat[2] = new float[4];
            Console.WriteLine("Вводите числа с плавающей точкой");
            for (int i = 0; i < arrayOfFloat.Length; i++)
            {
                for (int j = 0; j < arrayOfFloat[i].Length; j++)
                {
                    arrayOfFloat[i][j] = float.Parse(Console.ReadLine());
                }
            }

            //Создайте неявно типизированные переменные для хранения массива и строки. 
            var arr1 = new[] { 44, 5.5 };
            var arr2 = "wfdsjkfns";

            //Кортежи. Задайте кортеж из 5 элементов с типами int, string, char, string, ulong.  
            //Сделайте именование его элементов. 
            (int age, string color, char something, string character, ulong number) dog1 = (12, "white", 'a', "nice", 11121);
            //Выведите кортеж на консоль целиком и выборочно (1, 3, 4  элементы)
            Console.WriteLine(dog1);
            Console.WriteLine(dog1.age + "     " + dog1.something + "       " + dog1.character);
            //Выполните распаковку кортежа в переменные. 
            int age = dog1.age;
            string color = dog1.color;
            char smth = dog1.something;
            string character = dog1.character;
            ulong number = dog1.number;
            //Сравните два кортежа. 
            (int age, string color, char something, string character, ulong number) dog2 = (11, "white", 'a', "nice", 11);
            /*if (dog2.CompareTo(dog1) == -1)
            {
                Console.WriteLine("Это совсем не похожие собаки!");
            }
            else
            {
                Console.WriteLine("Это ооочень похожие собаки!");
            }*/
            if (dog1.Equals(dog2))
            {
                Console.WriteLine("Похожи!");
            }
            else
                Console.WriteLine("Вообще не похожи!");
            // Создайте локальную функцию в main и вызовите ее. Формальные параметры функции – массив целых и строка.
            (int max, int min, int sum, char first) fun(int[] arr, string str)
            {
                int min = arr[0];
                int max = arr[0];
                int sum = 0;
                foreach(int x in arr)
                {
                    if (min > x)
                    {
                        min = x;
                    }
                    if(max < x)
                    {
                        max = x;
                    }
                    sum += x;
                }
                return (max, min, sum, str[0]);
            }
            int[] smthForFunc = { 12, 2, -10, 22, 3 };
            (int max, int min, int sum, char letter) resOfFunc = fun(smthForFunc, "asdbjkds");
            Console.WriteLine();
            Console.WriteLine(resOfFunc) ;
            //Функция должна вернуть кортеж, содержащий: максимальный и минимальный элементы массива, сумму элементов массива и первую букву строки
            Console.ReadKey();
        }
    }
}
