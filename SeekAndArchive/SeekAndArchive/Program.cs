using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace SeekAndArchive
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = args[0];
            string directoryName = args[1];
            FoundFiles = new List<FileInfo>();
            watchers = new List<FileSystemWatcher>();


            DirectoryInfo rootDir = new DirectoryInfo(directoryName);
            if (!rootDir.Exists)
            {
                Console.WriteLine("The specified directory does not exists.");
                return;
            }

            RecursiveSearch(FoundFiles, fileName, rootDir);
            Console.WriteLine("Found {0} files.", FoundFiles.Count);

            foreach (FileInfo fiI in FoundFiles)
            {
                Console.WriteLine("{0}", fiI.FullName);
            }

            
        }
        static List<FileInfo> FoundFiles;

        static void RecursiveSearch(List<FileInfo> foundFiles, string fileName, DirectoryInfo currentDirectory)
        {
            foreach (FileInfo fiI in currentDirectory.GetFiles())
            {
                if (fiI.Name == fileName)
                    foundFiles.Add(fiI);
            }

            foreach (DirectoryInfo diI in currentDirectory.GetDirectories())
            {
                RecursiveSearch(foundFiles, fileName, diI);
            }
        }

        static List<FileSystemWatcher> watchers;

        static void WatcherChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType == WatcherChangeTypes.Changed)
                Console.WriteLine("{0} has been changed!", e.FullPath);

            foreach (FileInfo fil in FoundFiles)
            {
                Console.WriteLine("{0} has been changed!", e.FullPath);

                FileSystemWatcher senderWatcher = (FileSystemWatcher)sender;
                int index = watchers.IndexOf(senderWatcher, 0);

                ArchiveFile(archiveDirs[index], FoundFiles[index]);
            }

            for (int i = 0; i < FoundFiles.Count; i++)
            {
                archiveDirs = new List<DirectoryInfo>();
            }
        }

        static List<DirectoryInfo> archiveDirs;

        static void ArchiveFile(DirectoryInfo archiveDir, FileInfo fileToArchive)
        {
            FileStream input = fileToArchive.OpenRead();
            FileStream output = File.Create(archiveDir.FullName + @"\" + fileToArchive.Name + ".gz");

            GZipStream Compressor = new GZipStream(output, CompressionMode.Compress);

            int b = input.ReadByte();

            while (b != -1)
            {
                Compressor.WriteByte((byte)b);
                b = input.ReadByte();
            }

            Compressor.Close();
            input.Close();
            output.Close();
        }


    }
}
