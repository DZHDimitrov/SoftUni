using System;
using System.Linq;

namespace _01.DayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());
            int[] array = new int[numbers];
            for (int i = 0; i < numbers; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                array[i] = currentNumber;
            }
            Console.WriteLine(string.Join(" ", array.Reverse()));
        }
    }
}
