using System;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());

            for (int i = n1; i <= n2; i++)
            {
                for (int j = n1; j <= n2; j++)
                {
                    for (int k = n1; k <= n2; k++)
                    {
                        for (int l = n1; l <= n2; l++)
                        {
                            if (((i % 2 == 0 && l % 2 != 0) || (i % 2 != 0 && l % 2 == 0)) && i > l && (j + k) % 2 == 0)
                            {
                                Console.Write($"{i}{j}{k}{l} ");
                            }
                        }
                    }
                }
            }
        }
    }
}
