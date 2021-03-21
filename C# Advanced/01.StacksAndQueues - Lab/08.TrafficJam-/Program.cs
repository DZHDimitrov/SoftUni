using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();
            int counterCars = 0;
            Queue<string> queue = new Queue<string>();
            while (input != "end")
            {
                if (input == "green")
                {
                    for (int i = 0; i < numberOfCars; i++)
                    {
                        if (queue.Count == 0)
                        {
                            break;
                        }
                        Console.WriteLine($"{queue.Dequeue()} passed!");
                        counterCars++;

                    }
                }
                else
                {
                    queue.Enqueue(input);
                }
                input = Console.ReadLine();
            }


            Console.WriteLine($"{counterCars} cars passed the crossroads.");

        }
    }
}
