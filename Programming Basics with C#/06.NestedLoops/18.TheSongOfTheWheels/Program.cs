using System;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int controlValue = int.Parse(Console.ReadLine());
            bool hasFour = false;
            int counter = 0;
            int forth = 0;
            int a = 0;
            int b = 0;
            int c = 0;
            int d = 0;
            int aOnFour = 0;
            int bOnFour = 0;
            int cOnFour = 0;
            int dOnFour = 0;

            for (int i = 1000; i <= 9999; i++)
            {
                string currentNum = i.ToString();
                for (int j = 0; j < currentNum.Length; j++)
                {
                    int currentDigit = int.Parse(currentNum[j].ToString());

                    switch (j)
                    {
                        case 0:
                            a = currentDigit;
                            break;
                        case 1:
                            b = currentDigit;
                            break;
                        case 2:
                            c = currentDigit;
                            break;
                        case 3:
                            d = currentDigit;
                            break;
                    }
                }
                if (a < b && c > d && a * b + c * d == controlValue)
                {
                    counter++;
                    Console.Write($"{a}{b}{c}{d}" + " ");

                    if (counter == 4)
                    {
                        aOnFour = a;
                        bOnFour = b;
                        cOnFour = c;
                        dOnFour = d;
                        hasFour = true;
                    }
                }

            }
            if (hasFour)
            {
                Console.WriteLine();
                Console.WriteLine($"Password: {aOnFour}{bOnFour}{cOnFour}{dOnFour}");
            }
            else if (counter > 0 && counter < 4)
            {
                Console.WriteLine();
                Console.WriteLine("No!");
            }
            else if (counter == 0)
            {
                Console.WriteLine("No!");
            }

        }
    }
}