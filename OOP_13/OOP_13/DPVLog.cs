using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace OOP_13
{
    class DPVLog
    {
        public void Search()
        {
            string curTimeLong = DateTime.Now.ToLongTimeString();
            using (StreamWriter sw = new StreamWriter("dpvlogfile.txt", true, System.Text.Encoding.Default))
            {
                sw.WriteLine("\tPROTOCOL\n");
                sw.WriteLine(curTimeLong + "\nFile modified99999");
            }
        }
    }
}
