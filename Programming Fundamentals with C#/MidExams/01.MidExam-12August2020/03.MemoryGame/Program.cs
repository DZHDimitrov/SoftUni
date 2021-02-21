using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MemoryGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine().Split().ToList();

            string input = Console.ReadLine();
            int moves = 0;
            while (input != "end")
            {
                int[] cmdArgs = input.Split(' ',StringSplitOptions .RemoveEmptyEntries).Select(int.Parse).ToArray();
                int firstIndex = cmdArgs[0];
                int secondIndex = cmdArgs[1];
                moves++;
                if (firstIndex < 0 || firstIndex > elements.Count -1 || secondIndex < 0 || secondIndex > elements.Count -1)
                {
                    elements.Insert(elements.Count / 2,$"-{moves.ToString()}a");
                    elements.Insert(elements.Count / 2,$"-{moves.ToString()}a");
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                }
                else if (elements[firstIndex] == elements[secondIndex])
                {
                    Console.WriteLine($"Congrats! You have found matching elements - {elements[secondIndex]}!");
                    elements[firstIndex] = "removeme";
                    elements[secondIndex] = "removeme";
                    elements.RemoveAll(x => x == "removeme");

                }
                else if (elements[firstIndex] != elements[secondIndex])
                {
                    Console.WriteLine("Try again!");
                    input = Console.ReadLine();
                    continue;
                }
               
                if (AreDifferent(elements))
                {
                    Console.WriteLine($"You have won in {moves} turns!");
                    break;
                }

               
                input = Console.ReadLine();
            }
            if (!AreDifferent(elements))
            {
                Console.WriteLine("Sorry you lose :(");
                Console.WriteLine(string.Join(" ", elements));
            }
        }
        private static bool AreDifferent(List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                string currentItem = list[i];
                for (int j = i+1; j < list.Count; j++)
                {
                    if (currentItem == list[j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
