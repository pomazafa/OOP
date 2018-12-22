using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
namespace OOP_13
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DPVDiskInfo diskInfo = new DPVDiskInfo();
                diskInfo.DiskInfo();

                DPVFileInfo file = new DPVFileInfo();
                file.FileData("dpvlogfile.txt");

                DPVDirInfo dirInfo = new DPVDirInfo();
                dirInfo.DirInfo("ForInfo");

                DPVLog log = new DPVLog();
                log.Search();
               

                DPVFileManager manager = new DPVFileManager();
                manager.ReadDisk(DriveInfo.GetDrives()[0]);

                DPVFileManager.SearchByDate("12:47:17");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка:" + ex.Message);
            }
        }
    }
}
