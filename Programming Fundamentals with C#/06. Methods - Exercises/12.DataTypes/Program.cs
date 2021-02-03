using System;
using System.Collections.Generic;
using System.Threading;

class ExerciseMethods
{
    static void Main()
    {
        string input = Console.ReadLine();
        string secondInput = Console.ReadLine();
        switch (input)
        {
            case "int":
                MultiplyInt(int.Parse(secondInput));
                break;
            case "real":
                MultiplyDouble(double.Parse(secondInput));
                break;
            case "string":
                String(secondInput);
                break;
        }
    }

    static void MultiplyInt(int number)
    {
        int result = number * 2;
        Console.WriteLine(result);
    }
    static void MultiplyDouble(double number)
    {
        double result = number * 1.5;
        Console.WriteLine($"{result:F2}");
    }

    static void String(string text)
    {
        Console.WriteLine($"${text}$");
    }
}
