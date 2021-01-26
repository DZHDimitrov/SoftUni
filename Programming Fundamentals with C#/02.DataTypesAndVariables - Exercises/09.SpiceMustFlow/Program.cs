using System;
using System.Linq;

namespace CSharpAdvanced___2
{
    class Program
    {
        static void Main(string[] args)
        {
            int yield = int.Parse(Console.ReadLine());
            int total = 0;
            int days = 0;
            if (yield >= 100)
            {
                while (true)
                {
                    if (yield < 100)
                    {
                        total -= 26;
                        break;
                    }
                    total += yield - 26;
                    yield -= 10;
                    days++;
                }
                Console.WriteLine(days);
                Console.WriteLine(total);
            }
            else
            {
                Console.WriteLine(days);
                Console.WriteLine(total);
            }
        }
    }
}
