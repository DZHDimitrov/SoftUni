using System;

namespace ProgramingBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            double strawberriesprice = double.Parse(Console.ReadLine());
            double bananasquantity = double.Parse(Console.ReadLine());
            double orangesquantity = double.Parse(Console.ReadLine());
            double respquantity = double.Parse(Console.ReadLine());
            double strawberriesquantity = double.Parse(Console.ReadLine());

            double respprice = strawberriesprice / 2;
            double orangesprice = respprice - (0.40 * respprice);
            double bananasprice = respprice - (0.80 * respprice);
            double sum = strawberriesprice * strawberriesquantity + bananasquantity * bananasprice + orangesquantity * orangesprice + respquantity * respprice;

            Console.WriteLine($"{sum:F2}");
        }
    }
}


