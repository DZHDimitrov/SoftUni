using System;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            char sector = char.Parse(Console.ReadLine());
            int rowsFirstSector = int.Parse(Console.ReadLine());
            int seatsOddRow = int.Parse(Console.ReadLine());
            int allSeats = 0;

            for (char i = 'A'; i <= sector; i++)
            {
                for (int j = 1; j <= rowsFirstSector; j++)
                {
                    int symbol = 97;

                    if (j % 2 != 0)
                    {
                        for (int k = 1; k <= seatsOddRow; k++)
                        {
                            Console.WriteLine($"{i}{j}{(char)symbol}");
                            symbol++;
                            allSeats++;
                        }
                    }
                    else
                    {
                        for (int l = 1; l <= seatsOddRow + 2; l++)
                        {
                            Console.WriteLine($"{i}{j}{(char)symbol}");
                            symbol++;
                            allSeats++;
                        }
                    }

                }
                rowsFirstSector++;
            }
            Console.WriteLine($"{allSeats}");
        }

    }
}
