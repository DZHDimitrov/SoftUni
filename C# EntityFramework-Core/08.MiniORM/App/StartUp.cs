namespace ORM_Fundamentals
{
    using ORM_Fundamentals.App.Data;
    using ORM_Fundamentals.App.Data.Entities;
    using System.Linq;

    class StartUp
    {
        public static void Main()
        {
            SoftUniDbContext db = new SoftUniDbContext("Server=.\\SQLEXPRESS;Database=SoftUni;Trusted_Connection=True;MultipleActiveResultSets=true");

            db.Employees.Add(new Employee("Gosho", "Inserted", db.Departments.First().Id, true));

            Employee employee = db.Employees.Last();
            employee.FirstName = "Modified";

            db.SaveChanges();
        }
    }
}
