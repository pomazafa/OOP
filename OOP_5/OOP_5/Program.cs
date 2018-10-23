using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Exam ex1 = new Exam();
            ex1.Take();
            ((ITake)ex1).Take();
            

            var finalExam = new FinalExam();

            if(finalExam is Checkout)
            {
                Console.WriteLine("Exam is Checkout!");
            }
            else
            {
                Console.WriteLine("Exam is not Checkout");
            }

            finalExam.GetTypeName();

            var exam = finalExam as Exam;

            exam.GetTypeName();


            Console.WriteLine("---------- 6 ----------");

            List<Checkout> list = new List<Checkout>();
            var ex = new Exam();
            var fex = new FinalExam();
            var test = new Test();
            list.Add(ex);
            list.Add(fex);
            list.Add(test);

            var printer = new Printer();

            foreach(var item in list)
            {
                printer.IAmPrinting(item);
            }

            Console.ReadKey();
        }
    }
}
