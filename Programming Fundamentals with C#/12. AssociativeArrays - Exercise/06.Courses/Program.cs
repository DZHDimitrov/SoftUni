using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] cmdArgs = input.Split(" : ");
                string courseName = cmdArgs[0];
                string student = cmdArgs[1];

                if (!courses.ContainsKey(courseName))
                {
                    courses.Add(courseName, new List<string>());
                }
                courses[courseName].Add(student);

                input = Console.ReadLine();
            }

            foreach (var course in courses.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");
                foreach (var name in course.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {name}");
                }
            }
        }
    }
}
