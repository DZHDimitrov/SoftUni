using System;

namespace _07.NxN_Matrix_
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            PrintMatrix(number);
        }
        static void PrintMatrix(int number)
        {
            for (int i = 1; i <= number; i++)
            {
                for (int j = 0; j < number; j++)
                {
                    Console.Write(number + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
