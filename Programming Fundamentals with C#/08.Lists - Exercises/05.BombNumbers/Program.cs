using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int bombNumber = arr[0];
            int power = arr[1];

            for (int i = 0; i < list.Count; i++)
            {
                int rightPower = power;
                int leftPower = power;
                if (list[i] == bombNumber)
                {
                    while (leftPower > 0 && i > 0)
                    {
                        list.RemoveAt(i - 1);
                        i--;
                        leftPower--;
                    }
                    while (rightPower > 0 && i < list.Count -1)
                    {
                        list.RemoveAt(i + 1);                      
                        rightPower--;
                    }
                    list.RemoveAt(i--);
                }
            }
            Console.WriteLine(list.Sum());
        }
    }
}
