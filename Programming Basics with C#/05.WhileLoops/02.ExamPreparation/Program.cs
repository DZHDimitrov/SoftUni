using System;

namespace NewExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int badGradesTreshold = int.Parse(Console.ReadLine());

            int badGrades = 0;
            double allGrades = 0;
            double sumGrades = 0;
            bool isEnough = false;
            string lastProblem = "";

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Enough")
                {
                    isEnough = true;
                    break;
                }
                int currentGrade = int.Parse(Console.ReadLine());
                if (currentGrade <= 4)
                {
                    badGrades++;
                }
                if (badGrades >= badGradesTreshold)
                {
                    Console.WriteLine($"You need a break, {badGrades} poor grades.");
                    break;
                }
                if (input != "Enough")
                {
                    lastProblem = input;
                }
                sumGrades += currentGrade;
                allGrades++;
            }
            if (isEnough)
            {
                Console.WriteLine($"Average score: {sumGrades / allGrades:F2}");
                Console.WriteLine($"Number of problems: {allGrades}");
                Console.WriteLine($"Last problem: {lastProblem}");
            }


        }
    }
}
