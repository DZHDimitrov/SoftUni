using System;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int period = int.Parse(Console.ReadLine());
            int visitFor1Day = 7;
            int visited = 0;
            int unVisited = 0;

            for (int i = 1; i <= period; i++)
            {
                if (i % 3 == 0 && unVisited > visited)
                {
                    visitFor1Day++;
                }
                int peopleFor1day = int.Parse(Console.ReadLine());

                if (peopleFor1day <= visitFor1Day)
                {
                    visited += peopleFor1day;
                }

                else if (peopleFor1day > visitFor1Day)
                {
                    peopleFor1day -= visitFor1Day;
                    visited += visitFor1Day;
                    unVisited += peopleFor1day;
                }
            }
            Console.WriteLine($"Treated patients: {visited}.");
            Console.WriteLine($"Untreated patients: {unVisited}.");

        }
    }
}