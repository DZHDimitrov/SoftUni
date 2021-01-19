using System;

namespace ProgramingBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            double rent = double.Parse(Console.ReadLine());
            double cakeprice = rent * 0.20;
            double drinks = cakeprice * 0.55;
            double animator = rent / 3;
            double sum = rent + cakeprice + drinks + animator;
            Console.WriteLine(sum);
        }
    }
}


