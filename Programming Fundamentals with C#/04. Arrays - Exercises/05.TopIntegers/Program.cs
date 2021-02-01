using System;
using System.Linq;
using System.Text;

namespace _01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            for (int i = 0; i < arr.Length; i++)
            {
                int currentNum = arr[i];
                bool isTop = true;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] >= currentNum)
                    {
                        isTop = false;
                    }
                }
                if (isTop)
                {
                    Console.Write(arr[i] + " ");
                }
            }
        }
    }
}
