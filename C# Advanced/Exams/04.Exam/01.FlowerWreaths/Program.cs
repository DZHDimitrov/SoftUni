using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] lilies = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[] roses = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            Stack<int> stackLilies = new Stack<int>(lilies);
            Queue<int> queueRoses = new Queue<int>(roses);

            int storedFlowers = 0;
            int flowerWreaths = 0;
            while (stackLilies.Count > 0 && queueRoses.Count > 0)
            {
                int liliesValue = stackLilies.Peek();
                int rosesVlaue = queueRoses.Peek();
                if (liliesValue + rosesVlaue == 15)
                {
                    stackLilies.Pop();
                    queueRoses.Dequeue();
                    flowerWreaths++;
                }
                else if (liliesValue + rosesVlaue > 15)
                {
                    stackLilies.Pop();
                    stackLilies.Push(liliesValue - 2);
                }
                else if (liliesValue + rosesVlaue < 15)
                {

                    storedFlowers += (stackLilies.Pop() + queueRoses.Dequeue());
                }
            }
            int additionalWreaths = storedFlowers / 15;
            if (flowerWreaths + additionalWreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {flowerWreaths + additionalWreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5-(flowerWreaths + additionalWreaths)} wreaths more!");
            }
        }
    }
}
