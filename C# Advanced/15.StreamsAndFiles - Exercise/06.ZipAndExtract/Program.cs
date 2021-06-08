using System;
using System.IO;
using System.IO.Compression;

namespace _06.ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {

            string extractPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),"exercise.zip");
            ZipFile.CreateFromDirectory("../../../Files", extractPath);

            string resultPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),"MyResult");
            Directory.CreateDirectory(resultPath);
            ZipFile.ExtractToDirectory(extractPath, resultPath);

        }
    }
}
