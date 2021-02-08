using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            double savings = double.Parse(Console.ReadLine());
            List<int> drumsQuality = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> initialQualityList = new List<int>(drumsQuality.Count);
            for (int i = 0; i < drumsQuality.Count; i++)
            {
                initialQualityList.Add(drumsQuality[i]);
            }
            string input = Console.ReadLine();

            while (input != "Hit it again, Gabsy!")
            {
                int power = int.Parse(input);
                for (int i = 0; i < drumsQuality.Count; i++)
                {
                    drumsQuality[i] -= power;
                    if (drumsQuality[i] <= 0 && savings > initialQualityList[i] * 3)
                    {
                        drumsQuality[i] = initialQualityList[i];
                        savings -= drumsQuality[i] * 3;
                    }
                    else if (drumsQuality[i] <= 0 && savings <= initialQualityList[i] * 3)
                    {
                        initialQualityList.RemoveAt(i);
                        drumsQuality.RemoveAt(i--);
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", drumsQuality));
            Console.WriteLine($"Gabsy has {savings:F2}lv.");
        }

    }
}
