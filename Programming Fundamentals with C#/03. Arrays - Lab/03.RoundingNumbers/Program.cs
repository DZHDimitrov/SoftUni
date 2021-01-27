using System;
using System.Linq;

namespace _01.DayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] array = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"{Convert.ToDecimal(array[i])} => {Math.Round(Convert.ToDecimal(array[i]), MidpointRounding.AwayFromZero)}");
            }
        }
    }
}
