using System;
using System.Linq;

namespace _11._SnowBalls
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];
            //5
            //0K0K0
            //K000K
            //00K00
            //K000K
            //0K0K0

            //0K0KKK00
            //0K00KKKK
            //00K0000K
            //KKKKKK0K
            //K0K0000K
            //KK00000K
            //00K0K000
            //000K00KK

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string text = Console.ReadLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = text[j];
                }
            }
            int mostAtacks = 0;
            int row = 0;
            int col = 0;
            int toBeRemoved = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    int attacks = 0;
                    if (matrix[i, j] == 'K')
                    {
                        if (j + 2 <= matrix.GetLength(1) - 1 && i + 1 <= matrix.GetLength(0) - 1)
                        {
                            if (matrix[i + 1, j + 2] == 'K')
                            {
                                attacks++;
                            }
                        }
                        if (j + 2 <= matrix.GetLength(1) - 1 && i - 1 >= 0)
                        {
                            if (matrix[i - 1, j + 2] == 'K')
                            {
                                attacks++;
                            }
                        }
                        if (i - 2 >= 0 && j + 1 <= matrix.GetLength(1) - 1)
                        {
                            if (matrix[i - 2, j + 1] == 'K')
                            {
                                attacks++;
                            }
                        }
                        if (i - 2 >= 0 && j - 1 >= 0)
                        {
                            if (matrix[i - 2, j - 1] == 'K')
                            {
                                attacks++;
                            }
                        }
                        if (j - 2 >= 0 && i + 1 <= matrix.GetLength(0) - 1)
                        {
                            if (matrix[i + 1, j - 2] == 'K')
                            {
                                attacks++;
                            }
                        }
                        if (j - 2 >= 0 && i - 1 >= 0)
                        {
                            if (matrix[i - 1, j - 2] == 'K')
                            {
                                attacks++;
                            }
                        }
                        if (i + 2 <= matrix.GetLength(0) - 1 && j + 1 <= matrix.GetLength(1) - 1)
                        {
                            if (matrix[i + 2, j + 1] == 'K')
                            {
                                attacks++;
                            }
                        }
                        if (i + 2 <= matrix.GetLength(0) - 1 && j - 1 >= 0)
                        {
                            if (matrix[i + 2, j - 1] == 'K')
                            {
                                attacks++;
                            }
                        }
                        if (attacks > mostAtacks)
                        {
                            mostAtacks = attacks;
                            row = i;
                            col = j;
                        }

                    }
                }
                if (i == matrix.GetLength(0) - 1 && mostAtacks > 0)
                {
                    i = -1;
                    matrix[row, col] = '0';
                    mostAtacks = 0;
                    toBeRemoved++;
                }

            }
            Console.WriteLine(toBeRemoved);
        }
    }
}
