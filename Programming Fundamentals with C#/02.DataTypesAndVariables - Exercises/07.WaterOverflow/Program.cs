using System;
using System.Linq;

namespace CSharpAdvanced___2
{
    class Program
    {
        static void Main(string[] args)
        {
            int capacity = 255;
            int litersIn = 0;
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int currentLiters = int.Parse(Console.ReadLine());
                if (currentLiters + litersIn > capacity)
                {
                    Console.WriteLine("Insufficient capacity!");
                    continue;
                }
                litersIn += currentLiters;
            }

            Console.WriteLine(litersIn);
        }
    }
}
