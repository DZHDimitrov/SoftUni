using System;
using System.Linq;

namespace _02.VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[3];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }
            SmallestNumer(array);
        }
        static void SmallestNumer(int[] array)
        {
            Console.WriteLine(array.Min());
        }
    }
}
