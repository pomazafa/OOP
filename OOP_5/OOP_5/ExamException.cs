using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_5
{
    class ExamException : Exception
    {
        public ExamException(string message)
        : base(message)
        {
            Console.WriteLine("Вызвано исключение ExamException");
        }
    }
}
