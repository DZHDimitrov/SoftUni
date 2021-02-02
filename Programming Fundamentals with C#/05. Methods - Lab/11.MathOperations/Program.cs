using System;

namespace _10.MultiplyEvensByOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            char curOperator = char.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            double result = 0;
            switch (curOperator)
            {
                case '*':
                    result = Multiplication(first, second);
                    break;
                case '/':
                    result = Division(first, second);
                    break;
                case '-':
                    result = Subtaction(first, second);
                    break;
                case '+':
                    result = Add(first, second);
                    break;
            }
            Console.WriteLine(result);
        }

        static double Division(int firstNum, int secondNum)
        {
            double result = (firstNum * 1.00) / secondNum;
            return result;
        }
        static double Multiplication(int firstNumber, int secondNum)
        {
            double result = firstNumber * secondNum;
            return result;
        }
        static double Add(int firstNumber, int secondNumber)
        {
            double result = firstNumber + secondNumber;
            return result;
        }
        static double Subtaction(int firstNumber, int secondNumber)
        {
            double result = firstNumber - secondNumber;
            return result;
        }

    }
}
