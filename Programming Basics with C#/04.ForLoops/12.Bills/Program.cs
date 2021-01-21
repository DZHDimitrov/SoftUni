using System;

namespace Exercise_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int months = int.Parse(Console.ReadLine());

            int waterP = 20;
            int internetP = 15;
            int othersP = 0;

            double sumElectricity = 0;
            double sumWater = 0;
            double sumInternet = 0;
            double sumOthers = 0;
            double sumAll = 0;
            for (int i = 1; i <= months; i++)
            {
                double electricity = double.Parse(Console.ReadLine());

                sumElectricity += electricity;
                sumInternet += internetP;
                sumWater += waterP;
                sumOthers += electricity + internetP + waterP + ((electricity + internetP + waterP) * 0.20);

            }
            sumAll += sumElectricity + sumInternet + sumWater + sumOthers;

            Console.WriteLine($"Electricity: {sumElectricity:F2} lv");
            Console.WriteLine($"Water: {sumWater:F2} lv");
            Console.WriteLine($"Internet: {sumInternet:F2} lv");
            Console.WriteLine($"Other: {sumOthers:F2} lv");
            Console.WriteLine($"Average: {sumAll / months:F2} lv");
        }
    }
}