using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_5
{
    public class FinalExam : Exam
    {
        public override void GetTypeName()
        {
            Console.WriteLine("It is FinalExam");
        }

        public override string ToString()
        {
            return $"Type: {this.GetType().Name}; questions count: {this.Questions.Count}";
        }
    }
}
