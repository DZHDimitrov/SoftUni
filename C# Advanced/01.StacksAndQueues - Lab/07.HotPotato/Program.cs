using System;
using System.Collections.Generic;

namespace CSharpAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split();
            int passes = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>(array);

            while (queue.Count > 1)
            {
                for (int i = 1; i < passes; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }
                Console.WriteLine($"Removed {queue.Dequeue()}");
            }
            Console.WriteLine($"Last is {queue.Dequeue()}");

        }
    }
}