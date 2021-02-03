using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _11.ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                string text = i.ToString();
                int[] array = new int[text.Length];
                for (int j = 0; j < array.Length; j++)
                {
                    array[j] = int.Parse(text[j].ToString());
                }

                if (array.Sum() % 8 == 0 && array.Any(x => x % 2 != 0))
                {
                    Console.WriteLine(i);
                }
            }
        }

    }
}
