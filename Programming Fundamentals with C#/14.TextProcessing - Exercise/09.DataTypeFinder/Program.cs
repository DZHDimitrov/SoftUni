using System;
using System.Linq;
using System.Numerics;

namespace CSharpAdvanced___2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "END")
            {
                bool integerCheck = int.TryParse(input, out int integer);
                bool doubleCheck = double.TryParse(input, out double floating);
                bool charCheck = char.TryParse(input, out char myChar);
                bool boolCheck = bool.TryParse(input, out bool boolean);

                if (integerCheck)
                {
                    Console.WriteLine($"{input} is integer type");
                }
                else if (doubleCheck)
                {
                    Console.WriteLine($"{input} is floating point type");
                }
                else if (charCheck)
                {
                    Console.WriteLine($"{input} is character type");
                }
                else if (boolCheck)
                {
                    Console.WriteLine($"{input} is boolean type");
                }
                else
                {
                    Console.WriteLine($"{input} is string type");
                }
                input = Console.ReadLine();
            }

        }
    }
}
