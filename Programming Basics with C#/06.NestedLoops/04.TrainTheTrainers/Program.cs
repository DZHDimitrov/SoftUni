using System;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int trainers = int.Parse(Console.ReadLine());
            double allPresentationsScore = 0;
            int allGrades = 0;

            while (true)
            {
                string presentation = Console.ReadLine();
                if (presentation == "Finish")
                {
                    break;
                }
                double gradesSum = 0;
                for (int i = 1; i <= trainers; i++)
                {
                    double currentGrade = double.Parse(Console.ReadLine());
                    gradesSum += currentGrade;
                    allGrades++;
                }
                double averageScoreEach = gradesSum / trainers;
                allPresentationsScore += gradesSum;
                Console.WriteLine($"{presentation} - {averageScoreEach:F2}.");
            }
            Console.WriteLine($"Student's final assessment is {allPresentationsScore / allGrades:F2}.");
        }
    }
}