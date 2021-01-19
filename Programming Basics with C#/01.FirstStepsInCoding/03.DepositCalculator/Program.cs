using System;

namespace Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            double deposit = double.Parse(Console.ReadLine());
            int deadline = int.Parse(Console.ReadLine());
            double yearlyinterest = double.Parse(Console.ReadLine());

            double interest = (deposit * yearlyinterest) * 0.01;
            double monthlyinterest = interest / 12;
            double sum = deposit + (deadline * monthlyinterest);

            Console.WriteLine(sum);
        }
    }
}
