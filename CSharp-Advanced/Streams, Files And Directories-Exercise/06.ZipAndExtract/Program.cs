using System;
using System.IO;
using System.IO.Compression;

namespace _06.ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourceDirectory = @"../../../../Resources";
            string targetDirectory = @"../../../../result.zip";
            string destinationDirectory = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\result";
            ZipFile.CreateFromDirectory(sourceDirectory, targetDirectory);
            ZipFile.ExtractToDirectory(targetDirectory, destinationDirectory);
        }
    }
}
