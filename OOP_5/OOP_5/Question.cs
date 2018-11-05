using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_5
{
    public sealed class Question
    {
        public string Text
        {
            get { return text; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new QuestionException("Передана пустая строка! Вопрос не задан.");
                }
                else
                {
                    text = value;
                }   
            }
        }

        private string text;

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
