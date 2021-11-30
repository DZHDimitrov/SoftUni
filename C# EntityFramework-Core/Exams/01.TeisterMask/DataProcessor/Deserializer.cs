namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            XmlRootAttribute root = new XmlRootAttribute("Projects");
            var serializer = new XmlSerializer(typeof(ImportProjectDto[]), root);
            var projects = (ImportProjectDto[])serializer.Deserialize(new StringReader(xmlString));

            List<Project> dbProjects = new List<Project>();
            var sb = new StringBuilder();

            foreach (var project in projects)
            {
                if (!IsValid(project))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime projectOpenDate;

                var isOpenDateValid = DateTime.TryParseExact(project.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out projectOpenDate);

                if (!isOpenDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime? projectDueDate = null;

                if (!string.IsNullOrEmpty(project.DueDate))
                {
                    DateTime duteDateValue;

                    var isDuteDateValid = DateTime.TryParseExact(project.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out duteDateValue);

                    if (!isDuteDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    projectDueDate = duteDateValue;
                }

                var currentProject = new Project
                {
                    Name = project.Name,
                    OpenDate = projectOpenDate,
                    DueDate = projectDueDate,
                };

                foreach (var task in project.Tasks)
                {
                    if (!IsValid(task))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime taskOpenDate;

                    var isTaskOpenDateValid = DateTime.TryParseExact(task.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out taskOpenDate);

                    if (taskOpenDate < projectOpenDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime taskDueDate;

                    var isTaskDueDateValid = DateTime.TryParseExact(task.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out taskDueDate);

                    if (!isTaskDueDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (projectDueDate.HasValue && (taskDueDate > currentProject.DueDate))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var currentTask = new Task
                    {
                        Name = task.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = (ExecutionType)Enum.Parse(typeof(ExecutionType), task.ExecutionType),
                        LabelType = (LabelType)Enum.Parse(typeof(LabelType), task.LabelType)
                    };

                    currentProject.Tasks.Add(currentTask);
                }
                dbProjects.Add(currentProject);
                sb.AppendLine(string.Format(SuccessfullyImportedProject, project.Name, currentProject.Tasks.Count));
            }

            context.Projects.AddRange(dbProjects);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            ImportEmployeeDto[] employees = JsonConvert.DeserializeObject<ImportEmployeeDto[]>(jsonString);
            var sb = new StringBuilder();
            var dbEmployees = new List<Employee>();

            foreach (var employee in employees)
            {
                if (!IsValid(employee) || employee.Username.Any(x => !char.IsLetterOrDigit(x)))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var currentEmployee = new Employee
                {
                    Username = employee.Username,
                    Phone = employee.Phone,
                    Email = employee.Email
                };

                foreach (var taskInfo in employee.Tasks.Distinct())
                {
                    if (context.Tasks.All(x => x.Id != taskInfo))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var task = context.Tasks.FirstOrDefault(t => t.Id == taskInfo);

                    var empTask = new EmployeeTask
                    {
                        EmployeeId = currentEmployee.Id,
                        Employee = currentEmployee,
                        TaskId = task.Id,
                        Task = task,
                    };
                    currentEmployee.EmployeesTasks.Add(empTask);
                }
                dbEmployees.Add(currentEmployee);
                sb.AppendLine(string.Format(SuccessfullyImportedEmployee, currentEmployee.Username, currentEmployee.EmployeesTasks.Count));
            }

            context.Employees.AddRange(dbEmployees);

            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}