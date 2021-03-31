using System;
using System.Linq;

namespace FunctionalProgramming
{

    class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int start = range[0];
            int end = range[1];
            string typeNumbers = Console.ReadLine();
            int[] array = new int[end - start + 1];

            for (int i = start; i <= end; i++)
            {
                array[i - start] = i;
            }


            switch (typeNumbers)
            {
                case "odd":
                    Console.WriteLine(string.Join(" ", array.Where(x => x % 2 != 0)));
                    break;
                case "even":
                    Console.WriteLine(string.Join(" ", array.Where(x => x % 2 == 0)));
                    break;
            }

        }


    }
}
