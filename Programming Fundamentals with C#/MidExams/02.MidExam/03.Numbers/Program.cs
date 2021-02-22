using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace _03.Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            numbers = numbers.Where(x => x > numbers.Average()).OrderByDescending(x => x).Take(5).ToList();
            Console.WriteLine(numbers.Count > 0 ? string.Join(" ", numbers) : "No");
        }
    }
}
