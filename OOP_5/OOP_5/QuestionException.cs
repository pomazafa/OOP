﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_5
{
    public class QuestionException : Exception
    {
        public QuestionException(string message)
        : base(message)
        {
            Console.WriteLine("Исключение QuestionException");
        }
    }
}
