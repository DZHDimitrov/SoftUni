using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ObjectsAndClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Student> students = new List<Student>();

            while (input != "end")
            {
                string[] data = input.Split();

                string name = data[0];
                string lastname = data[1];
                int age = int.Parse(data[2]);
                string homeTown = data[3];


                Student student = new Student(name, lastname, age, homeTown);
                students = student.CheckIfExist(students, name, lastname);


                students.Add(student);

                input = Console.ReadLine();
            }
            string city = Console.ReadLine();

            foreach (Student student in students)
            {
                if (student.HomeTown == city)
                {
                    Console.WriteLine(student);
                }
            }
        }
    }



    class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }
        public string HomeTown { get; set; }

        public Student(string name, string lastname, int age, string hometown)
        {
            FirstName = name;
            LastName = lastname;
            Age = age;
            HomeTown = hometown;
        }

        public List<Student> CheckIfExist(List<Student> list, string firstname, string lastname)
        {
            int i = 0;

            foreach (Student student in list)
            {
                if (student.FirstName == firstname && student.LastName == lastname)
                {
                    list.RemoveAt(i);
                    break;
                }
                i++;
            }
            return list;

        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} is {Age} years old.";
        }
    }

}

