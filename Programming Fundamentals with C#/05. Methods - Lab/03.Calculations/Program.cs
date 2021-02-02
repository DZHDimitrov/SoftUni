using System;

namespace _03.Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            double number = double.Parse(Console.ReadLine());
            int operationNumber = int.Parse(Console.ReadLine());

            switch (command)
            {
                case "subtract":
                    Subtract(number, operationNumber);
                    break;
                case "divide":
                    Division(number, operationNumber);
                    break;
                case "multiply":
                    Multiply(number, operationNumber);
                    break;
                case "add":
                    Add(number, operationNumber);
                    break;
            }
        }

        static void Division(double number, int opNumber)
        {
            double result = number / opNumber;
            Console.WriteLine(result);
        }
        static void Add(double number, int opNumber)
        {
            double result = number + opNumber;
            Console.WriteLine(result);
        }
        static void Multiply(double number, int opNumber)
        {
            double result = number * opNumber;
            Console.WriteLine(result);
        }
        static void Subtract(double number, int opNumber)
        {
            double result = number - opNumber;
            Console.WriteLine(result);
        }
    }
}
