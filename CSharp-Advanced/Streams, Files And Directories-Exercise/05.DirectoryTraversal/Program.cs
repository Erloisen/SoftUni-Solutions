using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _05.DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileInfo = new Dictionary<string, Dictionary<string, double>>();
            DirectoryInfo directoryInfo = new DirectoryInfo("../../../");
            FileInfo[] files = directoryInfo.GetFiles(".");

            foreach (var eachFile in files)
            {
                if (!fileInfo.ContainsKey(eachFile.Extension))
                {
                    fileInfo.Add(eachFile.Extension, new Dictionary<string, double>());
                }

                fileInfo[eachFile.Extension].Add(eachFile.Name, eachFile.Length / 1024.0);
            }

            using StreamWriter reportWriter = new StreamWriter($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\report.txt");

            foreach (var file in fileInfo.OrderByDescending(f => f.Value.Count).ThenBy(i => i.Key))
            {
                reportWriter.WriteLine(file.Key);
                foreach (var item in file.Value.OrderBy(k => k.Value))
                {
                    reportWriter.WriteLine($"--{item.Key} - {item.Value:f3}kb");
                }
            }
        }
    }
}
