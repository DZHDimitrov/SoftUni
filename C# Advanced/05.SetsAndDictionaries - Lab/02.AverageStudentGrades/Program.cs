using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _11._SnowBalls
{
    class Program
    {
        static void Main(string[] args)
        {
            int students = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> grades = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < students; i++)
            {
                string[] array = Console.ReadLine().Split(' ');
                string name = array[0];
                decimal grade = decimal.Parse(array[1]);

                if (!grades.ContainsKey(name))
                {
                    grades.Add(name, new List<decimal>());
                }

                grades[name].Add(grade);
            }


            foreach (var item in grades)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < item.Value.Count; i++)
                {
                    sb.Append($"{item.Value[i]:F2} ");
                }
                Console.WriteLine($"{item.Key} -> {sb.ToString().Trim()} (avg: {item.Value.Average():F2})");
            }



        }
    }
}
