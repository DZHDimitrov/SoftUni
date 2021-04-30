using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] bombEffects = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[] bombCasing = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            Queue<int> bombEffectsQueue = new Queue<int>(bombEffects);
            Stack<int> bombCasingStack = new Stack<int>(bombCasing);

            Dictionary<string, int> bombs = new Dictionary<string, int>();
            bombs.Add("Cherry Bombs", 0);
            bombs.Add("Datura Bombs", 0);
            bombs.Add("Smoke Decoy Bombs", 0);

            while ((bombs["Cherry Bombs"] < 3 || bombs["Datura Bombs"] < 3 || bombs["Smoke Decoy Bombs"] < 3)&& (bombCasingStack.Count > 0 && bombEffectsQueue.Count > 0))
            {
                var bombEffectNum = bombEffectsQueue.Peek();
                var bombCasingNum = bombCasingStack.Peek();

                if (bombEffectNum + bombCasingNum == 40)
                {
                    bombs["Datura Bombs"]++;
                    bombEffectsQueue.Dequeue();
                    bombCasingStack.Pop();
                }
                else if (bombEffectNum + bombCasingNum == 60)
                {
                    bombs["Cherry Bombs"]++;
                    bombEffectsQueue.Dequeue();
                    bombCasingStack.Pop();
                }
                else if (bombEffectNum + bombCasingNum == 120)
                {
                    bombs["Smoke Decoy Bombs"]++;
                    bombEffectsQueue.Dequeue();
                    bombCasingStack.Pop();
                }
                else
                {
                    var num = bombCasingStack.Pop();
                    
                    bombCasingStack.Push(num -= 5);
                }
            }

            if (bombs["Cherry Bombs"] >= 3 && bombs["Datura Bombs"] >= 3 && bombs["Smoke Decoy Bombs"] >= 3)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }
            if (bombEffectsQueue.Count == 0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ",bombEffectsQueue)}");
            }
            if (bombCasingStack.Count == 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasingStack)}");
            }

            foreach (var bomb in bombs.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{bomb.Key}: {bomb.Value}");
            }
        }
    }
}