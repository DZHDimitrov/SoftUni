using System;

namespace _01.BonusScoringSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int students = int.Parse(Console.ReadLine());
            int countOfLectures = int.Parse(Console.ReadLine());
            int initialBonus = int.Parse(Console.ReadLine());

            double maxBonus = 0;
            int bestAttendancies = 0;
            for (int i = 0; i < students; i++)
            {
                int attendacies = int.Parse(Console.ReadLine());
                double bonus = (double)attendacies / countOfLectures * (5 + initialBonus);

                if (bonus > maxBonus)
                {
                    maxBonus = bonus;
                    bestAttendancies = attendacies;
                }
            }
            Console.WriteLine($"Max Bonus: {Math.Ceiling(maxBonus)}.");
            Console.WriteLine($"The student has attended {bestAttendancies} lectures.");

        }
    }
}
