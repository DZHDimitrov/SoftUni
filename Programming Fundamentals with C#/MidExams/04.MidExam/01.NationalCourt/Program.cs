using System;

namespace _01.NationalCourt
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstEmployeePplPerHour = int.Parse(Console.ReadLine());
            int secondEmployeePplPerHour = int.Parse(Console.ReadLine());
            int thirdEmployeePplPerHour = int.Parse(Console.ReadLine());

            int totalPeople = int.Parse(Console.ReadLine());

            int neededHours = 0;
            while (totalPeople > 0)
            {
                neededHours++;
                if (neededHours % 4 == 0)
                {
                    continue;
                }

                totalPeople -= firstEmployeePplPerHour;
                totalPeople -= secondEmployeePplPerHour;
                totalPeople -= thirdEmployeePplPerHour;


            }

            Console.WriteLine($"Time needed: {neededHours}h.");
        }
    }
}
