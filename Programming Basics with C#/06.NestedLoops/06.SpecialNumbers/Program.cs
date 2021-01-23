using System;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1111; i <= 9999; i++)
            {
                string input = i.ToString();
                int counter = 0;
                for (int j = 0; j < input.Length; j++)
                {
                    double currentDigit = double.Parse(input[j].ToString());
                    if (n % currentDigit == 0)
                    {
                        counter++;
                    }
                }
                if (counter == 4)
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}