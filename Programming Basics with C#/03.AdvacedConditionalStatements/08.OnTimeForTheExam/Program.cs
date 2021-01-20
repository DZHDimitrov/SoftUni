using System;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int examStartingTimeH = int.Parse(Console.ReadLine());
            int examStartingTimeM = int.Parse(Console.ReadLine());
            int examArrivalTimeH = int.Parse(Console.ReadLine());
            int examArrivalTimeM = int.Parse(Console.ReadLine());

            int examTimeM = examStartingTimeH * 60 + examStartingTimeM;
            int arrivalTimeM = examArrivalTimeH * 60 + examArrivalTimeM;


            if (arrivalTimeM <= examTimeM && examTimeM - arrivalTimeM <= 30)
            {
                Console.WriteLine("On time");
            }
            else if (arrivalTimeM <= examTimeM && examTimeM - arrivalTimeM > 30)
            {
                Console.WriteLine("Early");
            }
            else if (arrivalTimeM > examTimeM)
            {
                Console.WriteLine("Late");
            }
            if (arrivalTimeM < examTimeM && examTimeM - arrivalTimeM < 60)
            {
                Console.WriteLine($"{examTimeM - arrivalTimeM} minutes before the start");
            }
            else if (arrivalTimeM < examTimeM && examTimeM - arrivalTimeM >= 60)
            {
                Console.WriteLine($"{(examTimeM - arrivalTimeM) / 60}:{(examTimeM - arrivalTimeM) % 60:D2} hours before the start");
            }
            else if (arrivalTimeM > examTimeM && arrivalTimeM - examTimeM < 60)
            {
                Console.WriteLine($"{arrivalTimeM - examTimeM} minutes after the start");
            }
            else if (arrivalTimeM > examTimeM && arrivalTimeM - examTimeM >= 60)
            {
                Console.WriteLine($"{(arrivalTimeM - examTimeM) / 60}:{(arrivalTimeM - examTimeM) % 60:D2} hours after the start");
            }
        }
    }
}