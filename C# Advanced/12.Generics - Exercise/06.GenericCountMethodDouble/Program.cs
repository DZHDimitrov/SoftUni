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
            List<double> list = new List<double>();

            for (int i = 0; i < lines; i++)
            {
                double input = double.Parse(Console.ReadLine());
                list.Add(input);
            }

            double number = double.Parse(Console.ReadLine());

            var box = new Box<double>(list);

            Console.WriteLine(box.CountMethod(list, number));


        }
    }
}
