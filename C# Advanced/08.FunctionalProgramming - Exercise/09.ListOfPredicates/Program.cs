using System;
using System.Collections.Generic;
using System.Linq;

namespace FunctionalProgramming
{

    class Program
    {
        static void Main(string[] args)
        {
            int threshold = int.Parse(Console.ReadLine());

            int[] array = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Func<int, int, bool> func = (x, y) => x % y == 0;

            for (int i = 1; i <= threshold; i++)
            {
                int currentNumber = i;
                bool isDivisible = true;
                for (int j = 0; j < array.Length; j++)
                {
                    if (!func(i, array[j]))
                    {
                        isDivisible = false;
                        break;
                    }
                }
                if (isDivisible)
                {
                    Console.Write(i + " ");
                }
            }

        }

    }
}
