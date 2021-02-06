using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            List<string> guests = new List<string>();

            for (int i = 0; i < lines; i++)
            {
                string[] data = Console.ReadLine().Split();

                if (data.Contains("not"))
                {
                    if (guests.Contains(data[0]))
                    {
                        guests.Remove(data[0]);
                    }
                    else
                    {
                        Console.WriteLine($"{data[0]} is not in the list!");
                    }
                }
                else
                {
                    if (guests.Contains(data[0]))
                    {
                        Console.WriteLine($"{data[0]} is already in the list!");
                    }
                    else
                    {
                        guests.Add(data[0]);
                    }
                }
            }
            Console.WriteLine(string.Join("\n", guests));

        }

    }
}
