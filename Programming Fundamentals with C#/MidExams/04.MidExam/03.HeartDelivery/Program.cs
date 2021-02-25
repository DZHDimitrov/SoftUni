using System;
using System.Linq;

namespace _03.HeartDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split('@').Select(int.Parse).ToArray();

            string input = Console.ReadLine();

            int cupidIndex = 0;
            while (input != "Love!")
            {
                string[] cmdArgs = input.Split();
                cupidIndex += int.Parse(cmdArgs[1]);

                if (cupidIndex >= array.Length)
                {
                    cupidIndex = 0;
                }
                if (array[cupidIndex] > 0)
                {
                    array[cupidIndex] -= 2;
                    if (array[cupidIndex] == 0)
                    {
                        Console.WriteLine($"Place {cupidIndex} has Valentine's day.");
                    }

                }
                else if (array[cupidIndex] == 0)
                {
                    Console.WriteLine($"Place {cupidIndex} already had Valentine's day.");
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"Cupid's last position was {cupidIndex}.");

            if (array.Where(x => x == 0).Count() == array.Length)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid has failed {array.Where(x => x != 0).Count()} places.");
            }
        }
    }
}
