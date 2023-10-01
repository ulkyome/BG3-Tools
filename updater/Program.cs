using Aspose.Zip;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace updater
{
    internal class Program
    {
        public static string folderUpdate;
        public static string ver;
        static void Main(string[] args)
        {
            if(args.Length > 0)
            {
                ver = args[0];
                folderUpdate = args[1];
                OpenZip();
            }
            else {
                Console.WriteLine("Please enter a argument.");
                Console.ReadKey();
            }
        }

        public static void OpenZip()
        {
            using (FileStream zipFile = File.Open($"{folderUpdate}{ver}.zip", FileMode.Open))
            {
                using (var archive = new Archive(zipFile))
                {
                    try
                    {
                        archive.ExtractToDirectory(Environment.CurrentDirectory);
                    }
                    catch (IOException ex)
                    {
                        try
                        {
                            foreach (Process proc in Process.GetProcessesByName("BG3_Tools"))
                            {
                                proc.Kill();
                               
                            }
                            zipFile.Close();
                            archive.Dispose();
                            OpenZip();
                        }
                        catch (Exception exс)
                        {
                            Console.WriteLine(exс.Message);
                        }
                    }
                }
            }
        }
    }
}
