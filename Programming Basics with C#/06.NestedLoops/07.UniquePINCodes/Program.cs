using System;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            int n3 = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n1; i++)
            {
                for (int j = 1; j <= n2; j++)
                {
                    int counter = 0;
                    for (int k = 1; k <= n2; k++)
                    {
                        if (j % k == 0)
                        {
                            counter++;
                        }
                    }
                    for (int l = 1; l <= n3; l++)
                    {
                        if (i % 2 == 0 && l % 2 == 0 && counter == 2)
                        {
                            Console.WriteLine($"{i} {j} {l}");
                        }
                    }
                }
            }

        }
    }
}
