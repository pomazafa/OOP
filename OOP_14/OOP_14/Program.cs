using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Xml.Serialization;
using System.Xml.XPath;
using System.Xml;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OOP_14
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Binary");
                FinalExam fi = new FinalExam();
                fi.countOfQuest = 73;
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fs = new FileStream("finalExam.txt",
                FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, fi);
                }

                using (FileStream fs = new FileStream("finalExam.txt", FileMode.OpenOrCreate))
                {
                    FinalExam final = (FinalExam)formatter.Deserialize(fs);
                    Console.WriteLine($"Count of Questions: {final.countOfQuest}");
                }

                Console.WriteLine("soap");
                SoapFormatter soapFormatter = new SoapFormatter();
                using (Stream fStream = new FileStream("finalExam.txt",
                FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
                {
                    soapFormatter.Serialize(fStream, fi);
                }

                using (FileStream fs = new FileStream("finalExam.txt", FileMode.OpenOrCreate))
                {
                    FinalExam final = (FinalExam)soapFormatter.Deserialize(fs);
                    Console.WriteLine($"Count of Questions: {final.countOfQuest}");
                }

                Console.WriteLine("json");

                DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(FinalExam));
                using (FileStream fs = new FileStream("finalExam.json", FileMode.OpenOrCreate))
                {
                    jsonFormatter.WriteObject(fs, fi);
                }

                using (FileStream fs = new FileStream("finalExam.json", FileMode.OpenOrCreate))
                {
                    FinalExam final = (FinalExam)jsonFormatter.ReadObject(fs);
                    Console.WriteLine($"Count of Questions: {final.countOfQuest}");
                }

                Console.WriteLine("xml");

                XmlSerializer xSer = new XmlSerializer(typeof(FinalExam));
                using (FileStream fs = new FileStream("finalExam.xml", FileMode.OpenOrCreate))
                {
                    xSer.Serialize(fs, fi);
                }

                using (FileStream fs = new FileStream("finalExam.xml", FileMode.OpenOrCreate))
                {
                    FinalExam final = xSer.Deserialize(fs) as FinalExam;
                    Console.WriteLine($"Count of Questions: {final.countOfQuest}");
                }

                
                // 2 задание
                Console.WriteLine("\nArray");
                FinalExam[] finalExams = new FinalExam[] { new FinalExam(44), fi, new FinalExam(82), new FinalExam(40) };
                finalExams[0].Subject = "Math";
                finalExams[1].Subject = "Biology";
                finalExams[2].Subject = "Chemistry";
                finalExams[3].Subject = "PE";

                XmlSerializer xSer2 = new XmlSerializer(typeof(FinalExam[]));

                using (FileStream fs = new FileStream("Exams.xml", FileMode.OpenOrCreate))
                {
                    xSer2.Serialize(fs, finalExams);
                }

                using (FileStream fs = new FileStream("Exams.xml", FileMode.OpenOrCreate))
                {
                    FinalExam[] fis = (FinalExam[])xSer2.Deserialize(fs);
                    foreach (FinalExam fe in fis)
                        Console.WriteLine($"Count of Questions: {fe.countOfQuest}");
                }


                // 3 задание
                Console.WriteLine();
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load("Exams.xml");
                XmlElement xRoot = xDoc.DocumentElement;

                XmlNode childnode = xRoot.SelectSingleNode("FinalExam[Subject='Math']");
                if (childnode != null)
                    Console.WriteLine(childnode.OuterXml);

                Console.WriteLine();

                XmlNodeList childnodes = xRoot.SelectNodes("FinalExam[countOfQuest>45]");
                foreach (XmlNode n in childnodes)
                    Console.WriteLine(n.OuterXml);


                // 4 задание

                XDocument xDocument = XDocument.Load("exams.xml");

                var exs = xDocument.Element("ArrayOfFinalExam").Elements("FinalExam").Select(q => new
                {
                    subject = q.Element("Subject").Value,
                    count = q.Element("countOfQuest").Value,
                });
                using(StreamWriter sw = new StreamWriter("second.xml"))
                foreach (var x in exs)
                {
                    sw.WriteLine($"{x.subject} — {x.count} questions;");
                }
                Console.WriteLine();

            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.Message);
            }
        }
    } 
}
