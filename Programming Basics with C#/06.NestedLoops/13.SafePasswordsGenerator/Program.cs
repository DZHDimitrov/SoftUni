using System;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int max = int.Parse(Console.ReadLine());
            bool isMaxLetter = false;
            bool isMax = false;
            int passwords = 0;

            for (int i = 35; i < 55; i++)
            {
                for (int j = 64; j < 96; j++)
                {
                    for (int k = 1; k <= a; k++)
                    {
                        for (int l = 1; l <= b; l++)
                        {
                            passwords++;

                            Console.Write($"{(char)i}{(char)j}{k}{l}{(char)j}{(char)i}|");

                            if (passwords == max)
                            {
                                isMax = true;
                                break;
                            }
                            i++;
                            if (i > 55)
                            {
                                i = 35;
                            }

                            j++;
                            if (j > 96)
                            {
                                j = 64;
                            }

                        }
                        if (k == a)
                        {
                            isMaxLetter = true;
                            break;
                        }
                        if (isMax)
                        {
                            break;
                        }

                    }
                    if (isMaxLetter)
                    {
                        isMaxLetter = true;
                        break;
                    }
                    if (isMax)
                    {
                        break;
                    }
                }
                if (isMaxLetter)
                {
                    isMaxLetter = true;
                    break;
                }
                if (isMax)
                {
                    break;
                }
            }



        }

    }
}