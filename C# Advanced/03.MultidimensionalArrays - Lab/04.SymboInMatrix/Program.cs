using System;

namespace CSharpExercises

{
    class Program
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string data = Console.ReadLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = data[j];
                }
            }
            char elementToFind = char.Parse(Console.ReadLine());

            bool isFound = false;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == elementToFind)
                    {
                        Console.WriteLine($"({i}, {j})");
                        isFound = true;
                        break;
                    }
                }
                if (isFound)
                {
                    break;
                }
            }
            if (!isFound)
            {
                Console.WriteLine($"{elementToFind} does not occur in the matrix");
            }
        }
    }
}