using System;
using System.Linq;

namespace _03.ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] cmdArgs = Console.ReadLine().Split(@"\");

            string[] array = cmdArgs[cmdArgs.Length - 1].Split('.');
            Console.WriteLine($"File name: {array[0]}");
            Console.WriteLine($"File extension: {array[1]}");
        }
    }
}
