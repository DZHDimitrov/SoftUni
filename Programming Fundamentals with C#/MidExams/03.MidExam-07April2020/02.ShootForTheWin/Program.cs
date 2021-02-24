using System;
using System.Linq;

namespace _02.ShootForTheWin
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string input = Console.ReadLine();
            int shotTargets = 0;
            while (input != "End")
            {
                int index = int.Parse(input);

                if (index == -1 || index < 0 || index > array.Length - 1)
                {
                    input = Console.ReadLine();
                    continue;
                }
                int value = array[index];
                array = ModifyArray(array, value);
                array[index] = -1;
                shotTargets++;

                input = Console.ReadLine();
            }
            Console.WriteLine($"Shot targets: {shotTargets} -> {string.Join(" ", array)}");
        }
        private static int[] ModifyArray(int[] arr, int value)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != -1 && arr[i] > value)
                {
                    arr[i] -= value;
                }
                else if (arr[i] != -1 && arr[i] <= value)
                {
                    arr[i] += value;
                }
            }
            return arr;
        }
    }
}
