using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Xml.Serialization;
using System.Xml.XPath;
using System.Xml;
using System.Xml.Linq;
using System.Runtime.Serialization;

namespace OOP_14
{
    [DataContract]
    [Serializable]
    public class FinalExam : Exam
    {
        public FinalExam()
        {
            countOfQuest = 0;
        }

        public FinalExam(int c)
        {
            countOfQuest = c;
        }
        [DataMember]
        public int countOfQuest { get; set; }
        public override void GetTypeName()
        {
            Console.WriteLine("It is FinalExam");
        }
    }
}
