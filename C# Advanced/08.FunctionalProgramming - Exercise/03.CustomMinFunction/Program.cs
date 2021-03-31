using System;
using System.Linq;

namespace FunctionalProgramming
{

    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Func<int[], int> smallestNumber = CheckSmallestNumber;

            Console.WriteLine(smallestNumber(array));
        }
        static int CheckSmallestNumber(int[] array)
        {
            return array.Min();
        }

    }
}
