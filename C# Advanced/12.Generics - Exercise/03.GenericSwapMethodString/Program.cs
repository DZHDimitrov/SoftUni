using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericBoxOfString
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> items = new List<string>();
            int numbers = int.Parse(Console.ReadLine());
            for (int i = 0; i < numbers; i++)
            {
                string input = Console.ReadLine();
                items.Add(input);
            }

            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int first = arr[0];
            int second = arr[1];

            items = Method<string>.SwapElements(items, first, second);

            foreach (var item in items)
            {
                Console.WriteLine($"{item.GetType()}: {item}");
            }
        }
    }
}
