using Microsoft.Data.SqlClient;
using System;

namespace EntityFrameworkCore_ADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection connection = new SqlConnection(@"Server = .\SQLEXPRESS;Database = SoftUni;Integrated Security=true"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT FirstName AS TheFirstName, LastName AS SecondName,Salary FROM Employees WHERE FirstName LIKE 'D%'", connection);
                
                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        string firstName = (string)result["TheFirstName"];
                        string secondName = (string)result["SecondName"];
                        decimal salary = (decimal)result["Salary"];
                        Console.WriteLine(firstName + " " + secondName + " => " + salary);
                    }
                }
               

                SqlCommand increaseSalary = new SqlCommand("UPDATE Employees SET Salary *= 1.15", connection);
                int numOfPeopleWithIncreasedSalary = increaseSalary.ExecuteNonQuery();
                Console.WriteLine($"The salary of {numOfPeopleWithIncreasedSalary} was increased by 15%.");

               
                using (var secondResult = command.ExecuteReader())
                {
                    while (secondResult.Read())
                    {
                        string firstName = (string)secondResult["TheFirstName"];
                        string secondName = (string)secondResult["SecondName"];
                        decimal salary = (decimal)secondResult["Salary"];
                        Console.WriteLine(firstName + " " + secondName + " => " + salary);

                    }
                }
                
            }




        }
    }
}
