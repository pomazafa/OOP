using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Xml.XPath;
using System.Xml;
using System.Xml.Linq;
using System.Runtime.Serialization;
namespace OOP_14
{
    [Serializable]
    [DataContract]
    public class Exam : Checkout
    {
        public virtual void GetTypeName()
        {
            Console.WriteLine("It is Exam");
        }
    }
}
