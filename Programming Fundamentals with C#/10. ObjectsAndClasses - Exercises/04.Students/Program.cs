using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Articles2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int students = int.Parse(Console.ReadLine());
            List<Student> allStudents = new List<Student>();

            for (int i = 0; i < students; i++)
            {
                string[] data = Console.ReadLine().Split();
                Student student = new Student();
                student.FirstName = data[0];
                student.LastName = data[1];
                student.Grade = double.Parse(data[2]);

                allStudents.Add(student);
            }

            foreach (Student student in allStudents.OrderByDescending(x => x.Grade))
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:F2}");
            }


        }
    }
    class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double Grade { get; set; }
    }

}
