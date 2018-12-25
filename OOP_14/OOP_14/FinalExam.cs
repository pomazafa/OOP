using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_14
{
    [Serializable]
    public class FinalExam : Exam
    {
        public FinalExam()
        {
            countOfQuest = 0;
        }

        public FinalExam(int c)
        {
            countOfQuest = c;
        }
        public int countOfQuest { get; set; }
        public override void GetTypeName()
        {
            Console.WriteLine("It is FinalExam");
        }
    }
}
