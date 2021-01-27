using System;
using System.Linq;

namespace _01.DayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int sumEven = 0;
            int sumOdd = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    sumEven += array[i];
                }
                else if (array[i] % 2 != 0)
                {
                    sumOdd += array[i];
                }
            }
            Console.WriteLine(sumEven - sumOdd);
        }
    }
}
