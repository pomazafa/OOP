using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_5
{
    class SessionException : Exception
    {
        public SessionException(string message)
        : base(message)
        { }
    }
}
