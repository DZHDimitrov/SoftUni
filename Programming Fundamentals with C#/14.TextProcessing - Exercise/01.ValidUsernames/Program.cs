using System;
using System.Linq;

namespace _01.ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] cmdArgs = Console.ReadLine().Split(", ");

            foreach (var item in cmdArgs)
            {
                if (item.Length >= 3 && item.Length <= 16)
                {
                    if (isValid(item))
                    {
                        Console.WriteLine(item);
                    }
                }
            }
        }
        private static bool isValid(string text)
        {
            foreach (char item in text)
            {
                if (!(Char.IsLetterOrDigit(item) || item == '-' || item == '_'))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
