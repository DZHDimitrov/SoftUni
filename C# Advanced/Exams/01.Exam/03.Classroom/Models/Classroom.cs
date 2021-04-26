using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;

        public Classroom()
        {
            students = new List<Student>();
        }

        public Classroom(int capacity) : this()
        {
            Capacity = capacity;
        }
        

        public int Capacity { get; set; }

        public int Count => students.Count;

        public string RegisterStudent(Student student)
        {
            if (Count < Capacity)
            {
                students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            else
            {
                return $"No seats in the classroom";
            }
        }
        public string DismissStudent(string firstname, string lastname)
        {
            Student student = students.FirstOrDefault(x => x.FirstName == firstname && x.LastName == lastname);
            if (student != null)
            {
                students.Remove(student);
                return $"Dismissed student {student.FirstName} {student.LastName}";
            }
            else
            {
                return "Student not found";
            }
        }
        public string GetSubjectInfo(string subject)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Subject: {subject}");
            sb.AppendLine("Students:");

            foreach (Student student in students)
            {
                if (student.Subject == subject)
                {
                    sb.AppendLine($"{student.FirstName} {student.LastName}");
                }
            }
            if (!students.Any(x=>x.Subject == subject))
            {
                return "No students enrolled for the subject";
            }
            else
            {
                return sb.ToString().TrimEnd();
            }
        }
        public int GetStudentsCount()
        {
            return Count;
        }
        public Student GetStudent(string firstname, string lastname)
        {
            return students.FirstOrDefault(x => x.FirstName == firstname && x.LastName == lastname);
        }
    }
}
