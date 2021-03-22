using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            int petrolPumps = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>();

            for (int i = 0; i < petrolPumps; i++)
            {
                string currentPump = Console.ReadLine();
                currentPump += $" {i}";
                queue.Enqueue(currentPump);
            }

            int fuel = 0;
            for (int i = 0; i < petrolPumps; i++)
            {
                string currentInfo = queue.Dequeue();
                int[] array = currentInfo.Split().Select(int.Parse).ToArray();
                int petrol = array[0];
                int distance = array[1];
                fuel += petrol;
                if (fuel >= distance)
                {
                    fuel -= distance;
                }
                else
                {
                    fuel = 0;
                    i = -1;
                }
                queue.Enqueue(currentInfo);
            }
            var firstElement = queue.Dequeue().Split();
            Console.WriteLine(firstElement[2]);

        }
    }
}