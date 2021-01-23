using System;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int hundreds = int.Parse(Console.ReadLine());
            int tens = int.Parse(Console.ReadLine());
            int ones = int.Parse(Console.ReadLine());

            for (int i = 1; i <= hundreds; i++)
            {
                for (int j = 1; j <= tens; j++)
                {
                    int counter = 0;
                    for (int l = 1; l <= tens; l++)
                    {
                        if (j % l == 0)
                        {
                            counter++;
                        }
                    }
                    for (int k = 1; k <= ones; k++)
                    {
                        if (i % 2 == 0 && k % 2 == 0 && counter == 2)
                        {
                            Console.WriteLine($"{i} {j} {k}");
                        }
                    }
                }
            }
        }

    }
}