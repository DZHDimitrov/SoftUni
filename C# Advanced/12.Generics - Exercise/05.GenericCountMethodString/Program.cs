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
            List<string> list = new List<string>();

            for (int i = 0; i < lines; i++)
            {
                string input = Console.ReadLine();
                list.Add(input);
            }

            string element = Console.ReadLine();

            Box<string> box = new Box<string>(list);

            Console.WriteLine(box.CountMethod(list, element));
        }
    }
}
