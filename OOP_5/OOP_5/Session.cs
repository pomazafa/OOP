using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_5
{
    public class Session
    {
        public List<Checkout> exams { get; set; }
        public List<Checkout> tests { get; set; }

        public Session()
        {
            exams = new List<Checkout>();
            tests = new List<Checkout>();
        }

        public void AddExam(Checkout exam)
        {
            exams.Add(exam);
        }

        public void AddTest(Checkout test)
        {
            tests.Add(test);
        }

        public void RemoveExam(Checkout exam)
        {
            exams.Remove(exam);
        }

        public void RemoveTest(Checkout test)
        {
            tests.Remove(test);
        }

        public void Print()
        {
            Console.WriteLine("Exams:/n");
            foreach(var exam in exams)
            {
                Console.WriteLine($"Exam: {exam.Subject}");
            }
            Console.WriteLine();
            Console.WriteLine("Exams:/n");
            foreach (var test in tests)
            {
                Console.WriteLine($"Test: {test.Subject}");
            }
        }
    }
}
