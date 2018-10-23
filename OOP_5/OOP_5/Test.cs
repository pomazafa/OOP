using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_5
{
    public class Test : Checkout
    {
        public override bool Take()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"Type: {this.GetType().Name}; questions count: {this.Questions.Count}";
        }
    }
}
