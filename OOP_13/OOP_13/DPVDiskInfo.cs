using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace OOP_13
{
    class DPVDiskInfo
    {
        public void DiskInfo()
        {
            Console.WriteLine("\tDiskInfo");
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine("Drive name: {0}", drive.Name);
                Console.WriteLine("Drive type: {0}", drive.DriveType);
                if (!drive.IsReady) continue;
                Console.WriteLine("Volume Label: {0}", drive.VolumeLabel);
                Console.WriteLine("File system: {0}", drive.DriveFormat);
                Console.WriteLine("Root: {0}", drive.RootDirectory);
                Console.WriteLine("Total size: {0}", drive.TotalSize);
                Console.WriteLine("Free size: {0}", drive.TotalFreeSpace);
                Console.WriteLine("Available: {0}", drive.AvailableFreeSpace);
                Console.WriteLine();
            }
        }
    }
}
