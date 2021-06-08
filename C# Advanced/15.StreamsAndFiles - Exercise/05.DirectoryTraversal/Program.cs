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
            DirectoryInfo test = new DirectoryInfo(@"../../../");

            var files = test.GetFiles();
            var allFiles = new Dictionary<string, Dictionary<string, double>>();
            foreach (var item in files)
            {
                if (!allFiles.ContainsKey(item.Extension))
                {
                    allFiles.Add(item.Extension, new Dictionary<string, double>());
                }
                allFiles[item.Extension].Add(item.Name, item.Length / 1000);
            }

            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "exercise.txt");

            using FileStream stream = new FileStream(filePath, FileMode.CreateNew);
            using StreamWriter writer = new StreamWriter(stream);
            foreach (var item in allFiles.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                writer.WriteLine(item.Key);
                foreach (var file in item.Value.OrderBy(y => y.Value))
                {
                    writer.WriteLine($"--{file.Key} - {file.Value:F2}kb");
                }
            }

        }
    }
}
