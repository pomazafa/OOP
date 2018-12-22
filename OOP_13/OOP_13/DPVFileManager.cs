using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
//using System.IO.Compression.FileSystem;

namespace OOP_13
{
    class DPVFileManager
    {
        public void ReadDisk(DriveInfo drive)
        {
            //string path = drive.Name;
            //DirectoryInfo dirInfo = new DirectoryInfo(path);
            //string path2 = "dpvdirinfo.txt";
            //using (StreamWriter sw = new StreamWriter(path2, true, System.Text.Encoding.Default))
            //{

            //    sw.WriteLine("\nDrive " + path);
            //    if (!dirInfo.Exists)
            //    {
            //        Console.WriteLine("This directory dosen't exist");
            //    }
            //    else
            //    {
            //        sw.WriteLine("Files:");
            //        foreach (FileInfo file in dirInfo.GetFiles())
            //            sw.WriteLine(file.Name);
            //        sw.WriteLine("Directories:");
            //        foreach (DirectoryInfo dir in dirInfo.GetDirectories())
            //            sw.WriteLine(dir.Name);
            //    }
            //}
            //File.Copy(path2, "justCopy.txt");

            //DirectoryInfo di2 = new DirectoryInfo("..\\Debug");
            //Directory.CreateDirectory("Created");
            //Directory.CreateDirectory("DPVFiles");
            //foreach (FileInfo fi in di2.GetFiles())
            //{
            //    if (fi.Extension == ".txt")
            //        fi.CopyTo($"DPVFiles\\{fi.Name}");
            //}
            //Directory.Move("DPVFiles", "DPVFiles2");
            //File.Delete(path2);

            //string dirpath = @"DPVFiles2";
            //string zippath = @"DPVFiles.zip";
            //string unzippath = @"Unzipped";
            
           // ZipFile.CreateFromDirectory(dirpath, zippath);
            //ZipFile.ExtractToDirectory(zippath, unzippath); 
        }


        public static void SearchByDate(string date)
        {
            using (StreamReader sr = new StreamReader("dpvlogfile.txt"))
            {
                while (!sr.EndOfStream)
                {
                    //Console.WriteLine(sr.ReadLine());
                    if (sr.ReadLine().StartsWith(date))
                    {
                        Console.WriteLine(sr.ReadLine());
                    }
                }
            }
        }
    }
}
