using System;
using System.Linq;

namespace FunctionalProgramming
{

    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            string input = Console.ReadLine();

            while (input != "end")
            {
                switch (input)
                {
                    case "add":
                        array = Add(array);
                        break;
                    case "multiply":
                        array = Multiply(array);
                        break;
                    case "subtract":
                        array = Subtract(array);
                        break;
                    case "print":
                        Print(array);
                        break;
                }
                input = Console.ReadLine();
            }


        }
        static int[] Add(int[] array)
        {
            return array.Select(x => x + 1).ToArray();
        }
        static int[] Multiply(int[] array)
        {
            return array.Select(x => x * 2).ToArray();
        }
        static int[] Subtract(int[] array)
        {
            return array.Select(x => x - 1).ToArray();
        }
        static void Print(int[] array)
        {
            Console.WriteLine(string.Join(" ", array));
        }


    }
}
