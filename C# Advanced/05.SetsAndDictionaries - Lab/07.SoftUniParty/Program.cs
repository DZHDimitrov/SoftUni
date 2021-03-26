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
            HashSet<string> VIP = new HashSet<string>();
            HashSet<string> regulars = new HashSet<string>();

            while (input != "PARTY")
            {
                string code = input;
                if (char.IsDigit(input[0]))
                {
                    VIP.Add(code);
                }
                else
                {
                    regulars.Add(code);
                }
                input = Console.ReadLine();
            }
            string secondInput = Console.ReadLine();
            while (secondInput != "END")
            {
                string code = secondInput;

                if (VIP.Contains(code))
                {
                    VIP.Remove(code);
                }
                else if (regulars.Contains(code))
                {
                    regulars.Remove(code);
                }
                secondInput = Console.ReadLine();
            }

            Console.WriteLine(VIP.Count() + regulars.Count());

            foreach (var item in VIP)
            {
                Console.WriteLine(item);
            }
            foreach (var item in regulars)
            {
                Console.WriteLine(item);
            }

        }
    }
}
