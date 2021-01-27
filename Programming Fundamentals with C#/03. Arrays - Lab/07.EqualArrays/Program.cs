using System;
using System.Linq;

namespace _01.DayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayOne = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] arraySecond = Console.ReadLine().Split().Select(int.Parse).ToArray();
            bool areIdentical = true;
            int differenceIndex = 0;
            for (int i = 0; i < arrayOne.Length; i++)
            {
                if (arrayOne[i] != arraySecond[i])
                {
                    areIdentical = false;
                    differenceIndex = i;
                    break;
                }
            }
            if (areIdentical)
            {
                Console.WriteLine($"Arrays are identical. Sum: {arrayOne.Sum()}");
            }
            else
            {
                Console.WriteLine($"Arrays are not identical. Found difference at {differenceIndex} index");
            }

        }
    }
}
