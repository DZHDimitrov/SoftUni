using System;

namespace NewExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            double moneyInS = Math.Round(money * 100);
            int coins = 0;

            // cents = 2 , 1, 0.50 , 0.20 , 0.10 , 0.05, 0.02, 0.01;

            while (moneyInS > 0)
            {
                if (moneyInS >= 200)
                {
                    moneyInS -= 200;
                    coins++;
                }
                else if (moneyInS >= 100 && moneyInS < 200)
                {
                    moneyInS -= 100;
                    coins++;
                }
                else if (moneyInS >= 50 && moneyInS < 100)
                {
                    moneyInS -= 50;
                    coins++;
                }
                else if (moneyInS >= 20 && moneyInS < 50)
                {
                    moneyInS -= 20;
                    coins++;
                }
                else if (moneyInS >= 10 && moneyInS < 20)
                {
                    moneyInS -= 10;
                    coins++;
                }
                else if (moneyInS >= 5 && moneyInS < 10)
                {
                    moneyInS -= 5;
                    coins++;
                }
                else if (moneyInS >= 2 && moneyInS < 5)
                {
                    moneyInS -= 2;
                    coins++;
                }
                else if (moneyInS >= 1 && moneyInS < 2)
                {
                    moneyInS -= 1;
                    coins++;
                }
            }
            Console.WriteLine(coins);
        }
    }
}
