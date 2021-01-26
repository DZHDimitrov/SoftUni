using System;
using System.Linq;

namespace CSharpAdvanced___2
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = int.Parse(Console.ReadLine());
            int people = int.Parse(Console.ReadLine());
            int counter = 0;
            while (capacity > 0)
            {
                if (capacity - people < 0)
                {
                    counter++;
                    break;
                }
                capacity -= people;
                counter++;
            }
            Console.WriteLine(counter);
        }
    }
}
