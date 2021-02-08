using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.SoftUniCoursePlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> courses = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();

            string input = Console.ReadLine();

            while (input != "course start")

            {
                string[] data = input.Split(':', StringSplitOptions.RemoveEmptyEntries);
                string command = data[0];
                string currentCourse = data[1];
                switch (command)
                {
                    case "Add":
                        ;
                        if (!courses.Contains(currentCourse)) ;
                        {
                            courses.Add(currentCourse);
                        }
                        break;
                    case "Insert":
                        int index = int.Parse(data[2]);
                        if (!courses.Contains(currentCourse))
                        {
                            courses.Insert(index, currentCourse);
                        }
                        break;
                    case "Remove":
                        if (courses.Contains(currentCourse))
                        {
                            courses.Remove(currentCourse);
                        }
                        if (courses.Contains($"{currentCourse}-Exercise"))
                        {
                            courses.Remove($"{currentCourse}-Exercise");
                        }
                        break;
                    case "Swap":
                        if (courses.Contains(currentCourse) && courses.Contains(data[2]))
                        {
                            string courseOne = currentCourse;
                            string courseTwo = data[2];
                            int indexOfOne = courses.IndexOf(courseOne);
                            int indexOfTwo = courses.IndexOf(courseTwo);

                            courses.RemoveAt(indexOfOne);
                            courses.Insert(indexOfOne, courseTwo);
                            courses.RemoveAt(indexOfTwo);
                            courses.Insert(indexOfTwo, courseOne);

                            if (courses.Contains($"{courseOne}-Exercise"))
                            {
                                int indexOfExercise = courses.IndexOf($"{courseOne}-Exercise");
                                string randomWord = courses[indexOfTwo + 1];
                                courses.RemoveAt(indexOfExercise);
                                courses.Insert(indexOfTwo + 1, $"{courseOne}-Exercise");
                                courses.RemoveAt(indexOfTwo + 2);
                                courses.Insert(indexOfExercise - 1, randomWord);

                            }
                            if (courses.Contains($"{courseTwo}-Exercise"))
                            {
                                int indexOfExercise = courses.IndexOf($"{courseTwo}-Exercise");
                                string randomWord = courses[indexOfOne + 1];
                                courses.RemoveAt(indexOfExercise);
                                courses.Insert(indexOfOne + 1, $"{courseTwo}-Exercise");
                                courses.RemoveAt(indexOfOne + 2);
                                courses.Insert(indexOfExercise - 1, randomWord);
                            }

                        }
                        break;
                    case "Exercise":
                        if (courses.Contains(currentCourse) && !courses.Contains($"{currentCourse}-Exercise"))
                        {
                            int indexOfCourse = courses.IndexOf(currentCourse);
                            if (indexOfCourse > courses.Count - 1)
                            {
                                courses.Insert(indexOfCourse + 1, $"{currentCourse}-Exercise");
                            }
                            else if (indexOfCourse == courses.Count - 1)
                            {
                                courses.Add($"{currentCourse}-Exercise");
                            }
                        }
                        else if (!courses.Contains(currentCourse))
                        {
                            courses.Add(currentCourse);
                            courses.Add($"{currentCourse}-Exercise");
                        }
                        break;

                }
                input = Console.ReadLine();
            }
            int count = 1;
            foreach (var item in courses)
            {
                Console.WriteLine($"{count}.{item}");
                count++;
            }
        }
    }
}
