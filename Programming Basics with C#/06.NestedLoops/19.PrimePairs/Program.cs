using System;
using System.Linq;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            int end1 = int.Parse(Console.ReadLine());
            int end2 = int.Parse(Console.ReadLine());
            int firstCounter = 0;
            int secondCounter = 0;

            for (int i = n1; i <= n1 + end1; i++)
            {
                firstCounter = 0;
                for (int j = 1; j <= i; j++)
                {
                    if (i % j == 0)
                    {
                        firstCounter++;
                    }
                }
                for (int k = n2; k <= n2 + end2; k++)
                {
                    secondCounter = 0;
                    for (int l = 1; l <= k; l++)
                    {
                        if (k % l == 0)
                        {
                            secondCounter++;
                        }
                    }
                    if (firstCounter == 2 && secondCounter == 2)
                    {
                        Console.WriteLine($"{i}{k}");
                    }
                }
            }
        }
    }
}