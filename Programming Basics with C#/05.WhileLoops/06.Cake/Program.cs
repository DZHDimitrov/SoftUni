using System;

namespace NewExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int cakeWidth = int.Parse(Console.ReadLine());
            int cakeHight = int.Parse(Console.ReadLine());
            int sizeCake = cakeWidth * cakeHight;
            int piecesTaken = 0;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "STOP")
                {
                    Console.WriteLine($"{sizeCake} pieces are left.");
                    break;
                }

                int currentPiece = int.Parse(input);

                sizeCake -= currentPiece;
                piecesTaken += currentPiece;

                if (sizeCake <= 0)
                {
                    Console.WriteLine($"No more cake left! You need {Math.Abs(sizeCake)} pieces more.");
                    break;
                }
            }
        }
    }
}
