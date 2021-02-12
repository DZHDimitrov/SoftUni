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
            int n = int.Parse(Console.ReadLine());
            List<Employee> employees = new List<Employee>();
            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();

                Employee employee = new Employee();
                employee.Name = data[0];
                employee.Salary = double.Parse(data[1]);
                employee.Department = data[2];

                employees.Add(employee);
            }

            employees = employees.OrderBy(x => x.Department).ToList();

            Dictionary<string, List<double>> departments = new Dictionary<string, List<double>>();

            for (int i = 0; i < employees.Count; i++)
            {
                string newDepartment = employees[i].Department;
                double salary = employees[i].Salary;
                if (!departments.ContainsKey(newDepartment))
                {
                    departments[newDepartment] = new List<double>();
                }
                departments[newDepartment].Add(salary);
            }

            string maxAverageSalary = departments.OrderByDescending(x => x.Value.Average()).First().Key;

            employees = employees.Where(x => x.Department == maxAverageSalary).OrderByDescending(x => x.Salary).ToList();
            Console.WriteLine($"Highest Average Salary: {maxAverageSalary}");
            foreach (Employee employee in employees)
            {
                if (employee.Department == maxAverageSalary)
                {
                    Console.WriteLine($"{employee.Name} {employee.Salary:F2}");
                }
            }
        }
    }

    class Employee
    {
        public string Name { get; set; }
        public double Salary { get; set; }

        public string Department { get; set; }
    }

}

