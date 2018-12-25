using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_14
{
    [Serializable]
    public class Exam : Checkout
    {
        public virtual void GetTypeName()
        {
            Console.WriteLine("It is Exam");
        }
    }
}
