namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.Dtos.Import;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var departments = JsonConvert.DeserializeObject<ImportDepartmentsCellsDTO[]>(jsonString);

            var dbDepartments = new List<Department>();

            var sb = new StringBuilder();

            foreach (var dep in departments)
            {
                if (!IsValid(dep) || !dep.Cells.Any())
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                var dbDepartment = new Department
                {
                    Name = dep.Name,
                };

                bool isInvalidCell = false;
                foreach (var cell in dep.Cells)
                {
                    if (!IsValid(cell))
                    {
                        isInvalidCell = true;
                    }
                    dbDepartment.Cells.Add(new Cell { CellNumber = cell.CellNumber, HasWindow = cell.HasWindow });
                }
                if (isInvalidCell)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                dbDepartments.Add(dbDepartment);
                sb.AppendLine($"Imported {dep.Name} with {dep.Cells.Length} cells");
            }
            context.Departments.AddRange(dbDepartments);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var prisoners = JsonConvert.DeserializeObject<ImportPrisonersDTO[]>(jsonString);
            var dbPrisoners = new List<Prisoner>();
            var sb = new StringBuilder();
            foreach (var prisoner in prisoners)
            {
                if (!IsValid(prisoner))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                DateTime incarcerationDate;
                bool isIncarcerationDateValid = DateTime.TryParseExact(prisoner.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out incarcerationDate);
                if (!isIncarcerationDateValid)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                DateTime? releaseDate = null;

                if (!string.IsNullOrEmpty(prisoner.ReleaseDate))
                {
                    DateTime releaseDateValue;
                    bool isReleaseDateValid = DateTime.TryParseExact(prisoner.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out releaseDateValue);
                    if (!isReleaseDateValid)
                    {
                        sb.AppendLine("Invalid Data");
                        continue;
                    }
                    releaseDate = releaseDateValue;
                }

                var dbPrisoner = new Prisoner
                {
                    Nickname = prisoner.Nickname,
                    FullName = prisoner.FullName,
                    Age = prisoner.Age,
                    Bail = prisoner.Bail,
                    CellId = prisoner.CellId,
                    IncarcerationDate = incarcerationDate,
                    ReleaseDate = releaseDate
                };

                foreach (var mail in prisoner.Mails)
                {
                    dbPrisoner.Mails.Add(new Mail { Sender = mail.Sender, Address = mail.Address, Description = mail.Description });
                }
                dbPrisoners.Add(dbPrisoner);
                sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
            }
            context.Prisoners.AddRange(dbPrisoners);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ImportOfficerDto[]), new XmlRootAttribute("Officers"));
            var officers = serializer.Deserialize(new StringReader(xmlString)) as ImportOfficerDto[];

            var dbOfficers = new List<Officer>();

            var sb = new StringBuilder();

            foreach (var officer in officers)
            {
                if (!IsValid(officer))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                object position;
                ;
                if (!Enum.TryParse(typeof(Position), officer.Position, out position))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                object weapon;
                if (!Enum.TryParse(typeof(Weapon),officer.Weapon,out weapon))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var dbOfficer = new Officer
                {
                    FullName = officer.FullName,
                    Position = (Position)position,
                    Salary = officer.Salary,
                    DepartmentId = officer.DepartmentId,
                    Weapon = (Weapon)weapon
                };

                foreach (var priosner in officer.Prisoners)
                {
                    dbOfficer.OfficerPrisoners.Add(new OfficerPrisoner { PrisonerId = priosner.Id });
                }
                dbOfficers.Add(dbOfficer);
                sb.AppendLine($"Imported {dbOfficer.FullName} ({dbOfficer.OfficerPrisoners.Count} prisoners)");
            }
            context.Officers.AddRange(dbOfficers);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}