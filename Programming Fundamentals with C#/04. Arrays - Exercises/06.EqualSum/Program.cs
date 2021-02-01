using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace _01.DayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            bool indexExist = false;
            if (array.Length == 1)
            {
                Console.WriteLine(0);
                return;
            }
            for (int i = 0; i < array.Length; i++)
            {
                int currentNumber = array[i];
                int sumRight = 0;
                int sumLeft = 0;
                for (int j = i + 1; j < array.Length; j++)
                {
                    sumRight += array[j];
                }
                if (i > 0)
                {
                    for (int j = i - 1; j >= 0; j--)
                    {
                        sumLeft += array[j];
                    }
                }
                if (sumRight == sumLeft)
                {
                    Console.WriteLine(i);
                    indexExist = true;
                    break;
                }
            }
            if (!indexExist)
            {
                Console.WriteLine("no");
            }

        }
    }
}
