using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericBoxOfString
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            List<int> list = new List<int>();

            for (int i = 0; i < lines; i++)
            {
                int input = int.Parse(Console.ReadLine());
                list.Add(input);
            }

            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Box<int> box = new Box<int>(list);

            box.SwapElements(arr[0], arr[1]);
            Console.WriteLine(box.ToString());
        }
    }
}
