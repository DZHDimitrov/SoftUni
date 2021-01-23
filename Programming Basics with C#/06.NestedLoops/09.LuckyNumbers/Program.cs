using System;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());

            for (int i = 1000; i <= 9999; i++)
            {
                string text = i.ToString();
                double firstSum = 0;
                double secondSum = 0;
                bool isZero = false;
                for (int j = 0; j < text.Length; j++)
                {
                    int currentDigit = int.Parse(text[j].ToString());
                    if (currentDigit == 0)
                    {
                        isZero = true;
                        break;
                    }

                    if (j == 0 || j == 1)
                    {
                        firstSum += currentDigit;
                    }
                    else if (j == 2 || j == 3)
                    {
                        secondSum += currentDigit;
                    }
                }

                if (firstSum == secondSum && n1 % firstSum == 0 && isZero == false)
                {
                    Console.Write(i + " ");
                }
            }

        }
    }
}
