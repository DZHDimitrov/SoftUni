using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._SnowBalls
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] array = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            Dictionary<double, int> values = new Dictionary<double, int>();

            for (int i = 0; i < array.Length; i++)
            {
                if (!values.ContainsKey(array[i]))
                {
                    values.Add(array[i], 0);
                }

                values[array[i]]++;
            }

            foreach (var item in values)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
