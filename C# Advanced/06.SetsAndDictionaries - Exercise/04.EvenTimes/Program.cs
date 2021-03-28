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
            int numbers = int.Parse(Console.ReadLine());

            Dictionary<int, int> allNumbers = new Dictionary<int, int>();

            for (int i = 0; i < numbers; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                if (!allNumbers.ContainsKey(currentNumber))
                {
                    allNumbers.Add(currentNumber, 0);
                }
                allNumbers[currentNumber]++;
            }
            foreach (var item in allNumbers)
            {
                if (item.Value % 2 == 0)
                {
                    Console.WriteLine(item.Key);
                }
            }
        }
    }
}
