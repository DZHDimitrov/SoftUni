using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayOne = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[] arrayTwo = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int goal = int.Parse(Console.ReadLine());

            Stack<int> tasks = new Stack<int>(arrayOne);
            Queue<int> threads = new Queue<int>(arrayTwo);

            while (true)
            {
                int value = threads.Peek();
                if (tasks.Peek() == goal)
                {
                    Console.WriteLine($"Thread with value {value} killed task {goal}");
                    break;
                }
                else if (tasks.Peek() <= value)
                {
                    tasks.Pop();
                    threads.Dequeue();
                }
                else if (tasks.Peek() > value)
                {
                    threads.Dequeue();
                }
            }

            while (threads.Count > 0)
            {
                Console.Write(threads.Dequeue() + " ");
            }
        }
    }
}