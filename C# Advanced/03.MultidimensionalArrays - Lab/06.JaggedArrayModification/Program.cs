using System;
using System.Linq;

namespace CSharpExercises

{
    class Program
    {
        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jagged = new int[rows][];

            for (int i = 0; i < jagged.Length; i++)
            {
                int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
                jagged[i] = new int[array.Length];
                for (int j = 0; j < array.Length; j++)
                {
                    jagged[i][j] = array[j];
                }
            }

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] arr = input.Split();
                int row = int.Parse(arr[1]);
                int col = int.Parse(arr[2]);
                int value = int.Parse(arr[3]);
                bool isInvalid = false;

                if (row >= jagged.Length || row < 0)
                {
                    isInvalid = true;
                }
                else if (jagged[row].Length <= col || col < 0)
                {
                    isInvalid = true;
                }
                if (isInvalid)
                {
                    Console.WriteLine("Invalid coordinates");
                }
                else
                {
                    if (arr[0] == "Add")
                    {
                        jagged[row][col] += value;
                    }
                    else if (arr[0] == "Subtract")
                    {
                        jagged[row][col] -= value;
                    }


                }
                input = Console.ReadLine();
            }

            foreach (var item in jagged)
            {
                Console.WriteLine(string.Join(" ", item));
            }

        }
    }
}