using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_5
{
    public partial class Exam : Checkout, ITake
    {
        
        public override bool Take()
        {
            Console.WriteLine("Экзамен не сдан");
            return false;
        }

        public virtual void GetTypeName()
        {
            Console.WriteLine("It is Exam");
        }

        public override string ToString()
        {
            return $"Type: {this.GetType().Name}; questions count: {this.Questions.Count}";
        }
    }
}
