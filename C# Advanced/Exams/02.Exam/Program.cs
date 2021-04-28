using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstLootBox = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            int[] secondLootBox = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            Stack<int> stack = new Stack<int>(secondLootBox);
            Queue<int> queue = new Queue<int>(firstLootBox);

            List<int> claimedItems = new List<int>();

            while (true)
            {
                var firstItem = queue.Peek();
                var secondItem = stack.Pop();
                if ((firstItem + secondItem) % 2 == 0)
                {
                    claimedItems.Add(queue.Dequeue() + secondItem);
                }

                else
                {
                    queue.Enqueue(secondItem);
                }

                if (queue.Count == 0)
                {
                    Console.WriteLine("First lootbox is empty");
                    break;
                }
                if (stack.Count == 0)
                {
                    Console.WriteLine("Second lootbox is empty");
                    break;
                }
            }

            if (claimedItems.Sum() >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItems.Sum()}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItems.Sum()}");
            }
        }
    }
}