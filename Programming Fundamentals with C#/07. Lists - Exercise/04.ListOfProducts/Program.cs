using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SumAdjacentEqualNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int productsNumber = int.Parse(Console.ReadLine());

            List<string> products = new List<string>();

            for (int i = 0; i < productsNumber; i++)
            {
                products.Add(Console.ReadLine());
            }
            int index = 1;
            foreach (var item in products.OrderBy(x => x))
            {
                Console.WriteLine($"{index}.{item}");
                index++;
            }
        }

    }
}
