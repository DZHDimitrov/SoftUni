using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            int amountOfFood = int.Parse(Console.ReadLine());

            int[] lunches = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>(lunches);

            Console.WriteLine(queue.Max());

            while (amountOfFood > 0 && queue.Count > 0)
            {
                if (amountOfFood - queue.Peek() >= 0)
                {
                    amountOfFood -= queue.Dequeue();
                }
                else if (amountOfFood - queue.Peek() < 0)
                {
                    amountOfFood -= queue.Peek();
                }

            }
            if (queue.Count > 0)
            {
                Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
            }
            else if (queue.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}