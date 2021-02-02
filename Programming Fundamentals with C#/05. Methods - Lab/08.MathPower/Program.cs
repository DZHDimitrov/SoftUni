using System;

namespace _08.MathPower
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = int.Parse(Console.ReadLine());
            int degree = int.Parse(Console.ReadLine());
            double afterDegree = CalcDegree(number, degree);
            Console.WriteLine(afterDegree);
        }

        static double CalcDegree(double number,int degree)
        {
            double result = Math.Pow(number, degree);
            return result;
        }
    }
}
