using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_5
{
    public class Printer
    {
        public virtual void IAmPrinting(Checkout checkout)
        {
            Console.WriteLine($"Type: {checkout.GetType().Name}");
            Console.WriteLine($"ToString(): {checkout.ToString()}"); 
        }
    }
}
