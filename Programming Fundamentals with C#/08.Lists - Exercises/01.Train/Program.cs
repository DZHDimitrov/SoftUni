using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine().Split().Select(int.Parse).ToList();
            int capacity = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] arr = input.Split();

                if (arr[0] == "Add")
                {
                    wagons.Add(int.Parse(arr[1]));
                }
                else
                {
                    wagons = FitPassengers(wagons, int.Parse(arr[0]), capacity);
                }

                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", wagons));

        }
        static List<int> FitPassengers(List<int> list, int passengers, int capacity)
        {
            int passengersCount = passengers;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] + passengersCount <= capacity)
                {
                    list[i] += passengersCount;
                    break;
                }
            }
            return list;
        }
    }
}
