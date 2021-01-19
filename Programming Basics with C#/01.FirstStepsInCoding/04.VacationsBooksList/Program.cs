using System;

namespace ProgramingBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            int bookpages = int.Parse(Console.ReadLine());
            double readpagesperhour = double.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            double result = (bookpages / readpagesperhour) / days;
            Console.WriteLine(result);
        }
    }
}


