using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace EF___ADO.NET___exercise9
{
    class Program
    {
        private const string connectionStringOne = @"Server = .\SQLEXPRESS;Database = MinionsDBB;Integrated Security = true;";
        static void Main(string[] args)
        {
            using SqlConnection connection = new SqlConnection(connectionStringOne);
            connection.Open();
            int inputId = int.Parse(Console.ReadLine());

            string minionIdToUpdateQuery = @"usp_GetOlder";
            using SqlCommand updateYearsCmd = new SqlCommand(minionIdToUpdateQuery, connection);
            updateYearsCmd.CommandType = CommandType.StoredProcedure;
            updateYearsCmd.Parameters.AddWithValue("@id",inputId);
            Console.WriteLine(updateYearsCmd.ExecuteNonQuery());

            string getMinionInfoQuery = $"SELECT [Name],Age FROM Minions WHERE Id = @id";
            using SqlCommand takeInfoAboutMinion = new SqlCommand(getMinionInfoQuery, connection);
            takeInfoAboutMinion.Parameters.AddWithValue("@id", inputId);
            var reader = takeInfoAboutMinion.ExecuteReader();
            reader.Read();
            string name = reader["Name"].ToString().Trim();
            string age = reader["Age"].ToString().Trim();
            Console.WriteLine($"{name} – {age} years old");
        }
    }
}
