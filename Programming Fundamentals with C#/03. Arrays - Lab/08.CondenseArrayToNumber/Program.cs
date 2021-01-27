using System;
using System.Linq;

namespace _01.DayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int originalLength = array.Length - 1;

            if (array.Length < 1)
            {
                Console.WriteLine($"{array[0]} is already a condensed number");
                return;
            }
            for (int i = 0; i < originalLength; i++)
            {
                int[] newArr = new int[array.Length - 1];
                for (int j = 0; j < newArr.Length; j++)
                {
                    newArr[j] = array[j] + array[j + 1];
                }
                array = newArr;
            }

            Console.WriteLine(array[0]);
        }
    }
}
