using System;
using System.Linq;
using System.Numerics;

namespace CSharpAdvanced___2
{
    class Program
    {
        static void Main(string[] args)
        {
            sbyte snowBalls = sbyte.Parse(Console.ReadLine());

            BigInteger bestSnowBallValue = 0;
            int bestSnowBallSnow = 0;
            int bestSnowBallTime = 0;
            int bestSnowBallQuality = 0;

            for (int i = 0; i < snowBalls; i++)
            {
                int snowBallSnow = int.Parse(Console.ReadLine());
                int snowBallTime = int.Parse(Console.ReadLine());
                int snowBallQuality = int.Parse(Console.ReadLine());

                BigInteger snowBallValue = BigInteger.Pow((snowBallSnow / snowBallTime), snowBallQuality);

                if (snowBallValue > bestSnowBallValue)
                {
                    bestSnowBallValue = snowBallValue;
                    bestSnowBallSnow = snowBallSnow;
                    bestSnowBallTime = snowBallTime;
                    bestSnowBallQuality = snowBallQuality;
                }
            }

            Console.WriteLine($"{bestSnowBallSnow} : {bestSnowBallTime} = {bestSnowBallValue} ({bestSnowBallQuality})");

        }
    }
}
