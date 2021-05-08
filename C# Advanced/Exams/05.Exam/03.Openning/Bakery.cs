﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    class Bakery
    {
        List<Employee> data;


        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Employee>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count
        {
            get
            {
                return data.Count;
            }
        }

        public void Add(Employee employee)
        {
            if (data.Count < Capacity)
            {
                data.Add(employee);
            }
        }

        public bool Remove(string name)
        {
            var employee = data.FirstOrDefault(x => x.Name == name);

            if (employee == null)
            {
                return false;
            }
            else
            {
                data.Remove(employee);
                return true;
            }
        }
        public Employee GetOldestEmployee()
        {
            return data.OrderByDescending(x => x.Age).First();
        }
        public Employee GetEmployee(string name)
        {
            return data.FirstOrDefault(x => x.Name == name);
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Employees working at Bakery {Name}:");
            foreach (var item in data)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
