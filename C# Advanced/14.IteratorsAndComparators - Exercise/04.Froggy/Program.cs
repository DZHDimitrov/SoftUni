using System;
using System.Collections.Generic;
using System.Linq;

namespace Froggy
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] list = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            Lake firstLake = new Lake();
            Lake secondLake = new Lake();

            for (int i = 0; i < list.Length; i++)
            {
                if (i % 2 == 0)
                {
                    firstLake.Add(list[i]);
                }
                if (i % 2 != 0)
                {
                    secondLake.Add(list[i]);
                }
            }

            secondLake.MyReverse();
            Lake finalLake = new Lake();
            foreach (var item in firstLake)
            {
                finalLake.Add(item);
            }
            foreach (var item in secondLake)
            {
                finalLake.Add(item);
            }
            Console.WriteLine(string.Join(", ", finalLake));
            
        }
    }
}
