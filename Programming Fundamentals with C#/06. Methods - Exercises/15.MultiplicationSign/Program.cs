using System;
using System.Collections.Generic;
using System.Threading;

class ExerciseMethods
{
    static void Main()
    {
        int num1 = int.Parse(Console.ReadLine());
        int num2 = int.Parse(Console.ReadLine());
        int num3 = int.Parse(Console.ReadLine());
        Result(num1, num2, num3);
    }

    static void Result(int first, int second, int third)
    {
        if (first == 0 || second == 0 || third == 0)
        {
            Console.WriteLine("zero");
        }

        else if ((first > 0 && second > 0 && third > 0) || (first < 0 && second < 0 && third > 0) 
            || (first < 0 && second > 0 && third < 0) || (first > 0 && second < 0 && third < 0))
        {
            Console.WriteLine("positive");
        }
        else
        {
            Console.WriteLine("negative");
        }
    }





}
