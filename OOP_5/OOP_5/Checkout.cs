using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_5
{
    public abstract class Checkout
    {
        public string Subject { get; set; }
        public List<Question> Questions { get; set; }

        public Checkout()
        {
            Questions = new List<Question>();
        }

        public virtual void ShowQuestions()
        {
            foreach (Question x in Questions)
            {
                Console.WriteLine(x);
            }
        }

        public abstract bool Take();
    }
}
