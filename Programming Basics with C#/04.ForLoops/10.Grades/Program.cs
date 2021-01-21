using System;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int students = int.Parse(Console.ReadLine());

            int worst = 0;
            int bad = 0;
            int good = 0;
            int best = 0;
            double sumGrades = 0;

            for (int i = 1; i <= students; i++)
            {
                double currentGrade = double.Parse(Console.ReadLine());

                if (currentGrade >= 2.00 && currentGrade <= 2.99)
                {
                    worst++;
                }
                else if (currentGrade >= 3.00 && currentGrade <= 3.99)
                {
                    bad++;
                }
                else if (currentGrade >= 4.00 && currentGrade <= 4.99)
                {
                    good++;
                }
                else if (currentGrade >= 5.00)
                {
                    best++;
                }
                sumGrades += currentGrade;
            }
            Console.WriteLine($"Top students: {best * 1.00 / students * 100:F2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {good * 1.00 / students * 100:F2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {bad * 1.00 / students * 100:F2}%");
            Console.WriteLine($"Fail: {worst * 1.00 / students * 100:F2}%");
            Console.WriteLine($"Average: {sumGrades / students:F2}");
        }
    }
}