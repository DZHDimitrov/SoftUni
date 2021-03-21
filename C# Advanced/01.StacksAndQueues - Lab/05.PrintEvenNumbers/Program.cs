using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>(array);

            for (int i = 0; i < array.Length; i++)
            {
                int currentNumber = queue.Peek();
                if (currentNumber % 2 != 0)
                {
                    queue.Dequeue();
                }
                else
                {
                    queue.Enqueue(queue.Dequeue());
                }
            }
            Console.WriteLine(string.Join(", ", queue));
        }
    }
}