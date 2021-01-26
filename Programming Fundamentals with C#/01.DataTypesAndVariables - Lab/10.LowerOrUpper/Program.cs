using System;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string symbol = Console.ReadLine();
            if (symbol == symbol.ToUpper())
            {
                Console.WriteLine("upper-case");
            }
            else if (symbol == symbol.ToLower())
            {
                Console.WriteLine("lower-case");
            }

        }
    }
}