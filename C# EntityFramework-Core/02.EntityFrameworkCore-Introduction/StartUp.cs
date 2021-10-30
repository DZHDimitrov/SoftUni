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
        //Problem 02
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
        //Problem 03
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
        
         public static string GetEmployee147(SoftUniContext context)
        {
            var sb = new StringBuilder();
            var employee = context.Employees
                .Where(x => x.EmployeeId == 147)
                .Select(x => new
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    JobTitle = x.JobTitle,
                    Projects = x.EmployeesProjects
                                .Where(y => y.EmployeeId == x.EmployeeId)
                                .Select(y => new { ProjectName = y.Project.Name })
                                .OrderBy(y => y.ProjectName)
                                .ToList()
                })
                .FirstOrDefault();

            sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
            foreach (var project in employee.Projects)
            {
                sb.AppendLine(project.ProjectName);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var sb = new StringBuilder();
            var departments = context.Departments
                .Where(x => x.Employees.Count > 5)
                .OrderBy(x => x.Employees.Count)
                .ThenBy(x => x.Name)
                .Select(x => new
                {
                    DepartmentName = x.Name,
                    ManagerFirstName = x.Manager.FirstName,
                    ManagerLastName = x.Manager.LastName,
                    Employees = x.Employees
                                 .Select(y => new
                                 {
                                     FirstName = y.FirstName,
                                     LastName = y.LastName,
                                     JobTitle = y.JobTitle
                                 })
                                 .OrderBy(y => y.FirstName)
                                 .ThenBy(y => y.LastName)
                                 .ToList()
                }).ToList();

            foreach (var dep in departments)
            {
                sb.AppendLine($"{dep.DepartmentName} - {dep.ManagerFirstName} {dep.ManagerLastName}");
                foreach (var emp in dep.Employees)
                {
                    sb.AppendLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            var sb = new StringBuilder();
            var projects = context.Projects
                .OrderByDescending(x => x.StartDate)
                .Take(10)
                .Select(x => new
                {
                    Name = x.Name,
                    Description = x.Description,
                    StartDate = x.StartDate.ToString("M/d/yyyy h:mm:ss tt",CultureInfo.InvariantCulture)
                })
                .OrderBy(x => x.Name)
                .ToList();

            foreach (var project in projects)
            {
                sb.AppendLine(project.Name);
                sb.AppendLine(project.Description);
                sb.AppendLine(project.StartDate);
            }

            return sb.ToString().TrimEnd();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            var sb = new StringBuilder();
            var searchingDepartments = new string[] { "Engineering", "Tool Design", "Marketing", "Information Services" };
            var employees = context.Employees
                .Where(x => searchingDepartments.Contains(x.Department.Name))
                .AsQueryable();
            
            foreach (var emp in employees)
            {
                emp.Salary += emp.Salary * 0.12M;
            }
            context.SaveChanges();
            var selectedEmployees = employees
                .Select(x => new 
                { 
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Salary = x.Salary
                })
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            foreach (var emp in selectedEmployees)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} (${emp.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var sb = new StringBuilder();
            var employees = context.Employees
                .Where(x => x.FirstName.StartsWith("Sa"))
                .Select(x => new
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    JobTitle = x.JobTitle,
                    Salary = x.Salary
                })
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle} - (${emp.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            var sb = new StringBuilder();
            var projectToRemove = context.Projects.FirstOrDefault(x => x.ProjectId == 2);
            var employeesProjects = context.EmployeesProjects.Where(x => x.ProjectId == 2).ToList();

            foreach (var empProject in employeesProjects)
            {
                context.EmployeesProjects.Remove(empProject);
            }

            context.Projects.Remove(projectToRemove);

            context.SaveChanges();

            var projects = context.Projects
                .Take(10)
                .Select(x => x.Name)
                .ToList();

            foreach (var project in projects)
            {
                sb.AppendLine(project);
            }

            return sb.ToString().TrimEnd();
        }

        public static string RemoveTown(SoftUniContext context)
        {
            var employeesInTown = context.Employees.Where(x => x.Address.Town.Name == "Seattle").AsQueryable();
            foreach (var emp in employeesInTown)
            {
                emp.AddressId = null;
            }

            var addresses = context.Addresses.Where(x => x.Town.Name == "Seattle").ToList();
            foreach (var address in addresses)
            {
                context.Addresses.Remove(address);
            }
            var town = context.Towns.FirstOrDefault(x => x.Name == "Seattle");
            context.Towns.Remove(town);

            context.SaveChanges();

            return $"{addresses.Count} addresses in Seattle were deleted";
        }
    }
}
