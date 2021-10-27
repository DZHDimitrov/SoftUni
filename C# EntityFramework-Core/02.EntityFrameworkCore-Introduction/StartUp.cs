namespace SoftUni
{
    using SoftUni.Data;
    using SoftUni.Models;
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext db = new SoftUniContext();

            string result = GetAddressesByTown(db);

            Console.WriteLine(result);
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var sb = new StringBuilder();
            var employees = context.Employees.ToList();
            foreach (var employee in employees)
            {
                var line = $"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}";
                sb.AppendLine(line);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var sb = new StringBuilder();
            var employees = context.Employees
                .Where(x => x.Salary > 50000)
                .OrderBy(x => x.FirstName)
                .Select(x => new { Name = x.FirstName, Salary = x.Salary })
                .ToList();
            foreach (var employee in employees)
            {
                var line = $"{employee.Name} - {employee.Salary:f2}";
                sb.AppendLine(line);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var sb = new StringBuilder();
            var employees = context.Employees
                .Where(x => x.Department.Name == "Research and Development")
                .OrderBy(x => x.Salary)
                .ThenByDescending(x => x.FirstName)
                .Select(x => new { FirstName = x.FirstName, LastName = x.LastName, Department = x.Department.Name, Salary = x.Salary })
                .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.Department} - ${employee.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var address = new Address() { AddressText = "Vitoshka 15", TownId = 4 };
            context.Addresses.Add(address);

            var employee = context.Employees.First(x => x.LastName == "Nakov");
            employee.Address = address;
            context.SaveChanges();

            var employees = context.Employees
                .OrderByDescending(x => x.AddressId)
                .Select(x => new { AddressText = x.Address.AddressText })
                .Take(10)
                .ToList();

            foreach (var emp in employees)
            {
                sb.AppendLine(emp.AddressText);
            }
            return sb.ToString().TrimEnd();
        }
        
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var sb = new StringBuilder();
            var employees = context.Employees
                .Where(x => x.EmployeesProjects
                             .Any(y => y.Project.StartDate.Year >= 2001 && y.Project.StartDate.Year <= 2003))
                .Select(x =>
                new
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    ManagerFirstName = x.Manager.FirstName,
                    ManagerLastName = x.Manager.LastName,
                    Projects = x.EmployeesProjects
                                .Where(y => y.EmployeeId == x.EmployeeId)
                                .Select(x => new
                                {
                                    ProjectName = x.Project.Name,
                                    StartDate = x.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                                    EndDate = x.Project.EndDate.HasValue ?
                                              x.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) 
                                              : "not finished"
                                }).ToList()
                })
                .Take(10)
                .ToList();
            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} - Manager: {emp.ManagerFirstName} {emp.ManagerLastName}");

                foreach (var project in emp.Projects)
                {
                    sb.AppendLine($"--{project.ProjectName} - {project.StartDate} - {project.EndDate}");
                }
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var sb = new StringBuilder();
            var addresses = context.Addresses
                .OrderByDescending(x => x.Employees.Count)
                .ThenBy(x => x.Town.Name)
                .ThenBy(x=>x.AddressText)
                .Take(10)
                .Select(x => new { AddressText = x.AddressText, TownName = x.Town.Name, EmployeesCount = x.Employees.Count })
                .ToList();

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.TownName} - {address.EmployeesCount} employees");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
