using System;
using System.Collections.Generic;
using System.Threading;

class ExerciseMethods
{
    static void Main()
    {
        double x = double.Parse(Console.ReadLine());
        double y = double.Parse(Console.ReadLine());
        double x1 = double.Parse(Console.ReadLine());
        double y1 = double.Parse(Console.ReadLine());
        Calculation(x, y, x1, y1);
    }

    static void Calculation(double x, double y, double x1, double y1)
    {
        double first = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        double second = Math.Sqrt(Math.Pow(x1, 2) + Math.Pow(y1, 2));

        if (first < second)
        {
            Console.WriteLine($"({x}, {y})");
        }
        else
        {
            Console.WriteLine($"({x1}, {y1})");
        }
    }


}
