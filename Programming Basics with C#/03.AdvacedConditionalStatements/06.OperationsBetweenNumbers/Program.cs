using System;

namespace Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int N1 = int.Parse(Console.ReadLine());
            int N2 = int.Parse(Console.ReadLine());
            string op = Console.ReadLine();

            if (op == "+")
            {
                int result = N1 + N2;
                if (result % 2 == 0)
                {
                    Console.WriteLine($"{N1} {op} {N2} = {result} - even");
                }

                else if (result % 2 != 0)
                {
                    Console.WriteLine($"{N1} {op} {N2} = {result} - odd");
                }
            }
            else if (op == "-")
            {
                int result = N1 - N2;
                if (result % 2 == 0)
                {
                    Console.WriteLine($"{N1} {op} {N2} = {result} - even");
                }
                else if (result % 2 != 0)
                {
                    Console.WriteLine($"{N1} {op} {N2} = {result} - odd");
                }
            }

            else if (op == "*")
            {
                int result = N1 * N2;
                if (result % 2 == 0)
                {
                    Console.WriteLine($"{N1} {op} {N2} = {result} - even");
                }
                else if (result % 2 != 0)
                {
                    Console.WriteLine($"{N1} {op} {N2} = {result} - odd");
                }
            }

            else if (op == "/")
            {
                double result = (N1 * 1.00) / (N2 * 1.00);
                if (N2 != 0)
                {
                    Console.WriteLine($"{N1} {op} {N2} = {result:F2}");
                }
                else if (N2 == 0)
                {
                    Console.WriteLine($"Cannot divide {N1} by zero");
                }
            }

            else if (op == "%")
            {
                if (N2 != 0)
                {
                    int result = N1 % N2;
                    Console.WriteLine($"{N1} {op} {N2} = {result}");
                }
                else if (N2 == 0)
                {
                    Console.WriteLine($"Cannot divide {N1} by zero");
                }

            }
        }
    }
}
