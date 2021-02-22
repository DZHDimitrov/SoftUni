using System;

namespace _01.SoftUniReception
{
    class Program
    {
        static void Main(string[] args)
        {
            int workerOneStudentsPerHour = int.Parse(Console.ReadLine());
            int workerTwoStudentsPerHour = int.Parse(Console.ReadLine());
            int workerThreeStudentsPerHour = int.Parse(Console.ReadLine());
            int allStudents = int.Parse(Console.ReadLine());

            int hoursNeeded = 1;


            while (allStudents > 0)
            {
                if (hoursNeeded % 4 == 0)
                {
                    hoursNeeded++;
                    continue;
                }


                if (allStudents != 0)
                {
                    allStudents = CalcStudents(workerOneStudentsPerHour, allStudents);
                }

                if (allStudents != 0)
                {
                    allStudents = CalcStudents(workerTwoStudentsPerHour, allStudents);
                }

                if (allStudents != 0)
                {
                    allStudents = CalcStudents(workerThreeStudentsPerHour, allStudents);

                }
                hoursNeeded++;
            }
            Console.WriteLine($"Time needed: {hoursNeeded - 1}h.");

        }
        public static int CalcStudents(int studentsPerHour, int allStudents)
        {
            for (int i = 0; i < studentsPerHour; i++)
            {
                allStudents--;
                if (allStudents == 0)
                {
                    return allStudents;
                }
            }
            return allStudents;
        }
    }
}
