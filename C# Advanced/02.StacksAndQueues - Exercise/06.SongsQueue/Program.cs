using System;
using System.Collections.Generic;

namespace CSharpAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine().Split(", ");
            Queue<string> queue = new Queue<string>(songs);

            while (queue.Count > 0)
            {
                string[] data = Console.ReadLine().Split();
                string command = data[0];

                switch (command)
                {
                    case "Play":
                        queue.Dequeue();
                        break;
                    case "Add":
                        string songToAdd = string.Join(" ", data).Substring(command.Length + 1);
                        if (!queue.Contains(songToAdd))
                        {
                            queue.Enqueue(songToAdd);
                        }
                        else
                        {
                            Console.WriteLine($"{songToAdd} is already contained!");
                        }
                        break;
                    case "Show":
                        Console.WriteLine(string.Join(", ", queue));
                        break;
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}