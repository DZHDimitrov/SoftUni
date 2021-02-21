using System;
using System.Linq;

namespace _02.TheLift
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleWaiting = int.Parse(Console.ReadLine());
            int[] wagons = Console.ReadLine().Split().Select(int.Parse).ToArray();
            bool arePeople = true;
            for (int i = 0; i < wagons.Length; i++)
            {
                while (wagons[i] < 4)
                {
                    peopleWaiting--;
                    wagons[i]++;
                    if (peopleWaiting == 0)
                    {
                        arePeople = false;
                        break;
                    }
                }
                if (arePeople == false)
                {
                    break;
                }
            }
            bool areEmptySpots = false;
            for (int i = 0; i < wagons.Length; i++)
            {
                if (wagons[i] < 4)
                {
                    areEmptySpots = true;
                }
            }
            if (!areEmptySpots && peopleWaiting == 0)
            {
                Console.WriteLine(string.Join(" ", wagons));
                return;
            }
            if (areEmptySpots)
            {
                Console.WriteLine("The lift has empty spots!");
                Console.WriteLine(string.Join(" ", wagons));
            }
            else
            {
                Console.WriteLine($"There isn't enough space! {peopleWaiting} people in a queue!");
                Console.WriteLine(string.Join(" ", wagons));
            }
        }
    }
}
