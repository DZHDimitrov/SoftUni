using System;
using System.Linq;

namespace _01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int wagons = int.Parse(Console.ReadLine());
            int[] array = new int[wagons];
            for (int i = 0; i < wagons; i++)
            {
                int people = int.Parse(Console.ReadLine());
                array[i] = people;
            }
            Console.WriteLine(string.Join(" ", array));
            Console.WriteLine(array.Sum());
        }
    }
}
