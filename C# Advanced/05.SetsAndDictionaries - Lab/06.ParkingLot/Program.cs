using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace _01.DayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            HashSet<string> carNumbers = new HashSet<string>();
            while (input != "END")
            {
                string[] array = input.Split(", ");

                if (array[0] == "IN")
                {
                    carNumbers.Add(array[1]);
                }
                else if (array[0] == "OUT")
                {
                    carNumbers.Remove(array[1]);
                }

                input = Console.ReadLine();
            }
            if (carNumbers.Count > 0)
            {
                foreach (var item in carNumbers)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
