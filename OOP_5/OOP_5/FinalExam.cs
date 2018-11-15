using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

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
            
            Debug.Assert(Questions.Count != 0, "Не задано ни одного вопроса в FinalExam!!!");
            return $"Type: {this.GetType().Name}; questions count: {this.Questions.Count}";
        }
    }
}
