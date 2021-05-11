using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace EF_ADO.NET_exercise5
{
    class Program
    {
        private const string connectionString = @"Server = .\SQLEXPRESS;Database = MinionsDBB;Integrated Security = true";
        static void Main(string[] args)
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            string country = Console.ReadLine();

            string countryId = FindCountryId(connection,country);

            ChangeTownNames(connection,countryId);

            List<string> citiesAffected = GetCitiesAffected(connection,countryId);

            if (citiesAffected.Count == 0)
            {
                Console.WriteLine("No town names were affected.");
            }
            else
            {
                Console.WriteLine($"{citiesAffected.Count} town names were affected.");
                Console.WriteLine($"[{string.Join(", ", citiesAffected)}]");
            }
            

        }
        private static string FindCountryId(SqlConnection connection,string country)
        {
            string findCountryIdQuery = @"SELECT Id FROM Countries WHERE [Name] = @name";
            SqlCommand takeCountryIdCmd = new SqlCommand(findCountryIdQuery, connection);
            takeCountryIdCmd.Parameters.AddWithValue("@name", country);
            string countryId = takeCountryIdCmd.ExecuteScalar()?.ToString();
            return countryId;
        }
        private static void ChangeTownNames(SqlConnection connection, string countryId)
        {
            string changeCitiesQuery = @"UPDATE Towns SET [Name] = UPPER([NAME]) WHERE CountryCode = @countryid";
            SqlCommand updateCitiesNameCmd = new SqlCommand(changeCitiesQuery, connection);
            updateCitiesNameCmd.Parameters.AddWithValue("@countryid", countryId);
            updateCitiesNameCmd.ExecuteNonQuery();
        }
        private static List<string> GetCitiesAffected(SqlConnection connection, string countryId)
        {
            string findAllTownsToCountryQuery = @"SELECT [Name] FROM Towns WHERE CountryCode = @id";
            SqlCommand findAllTownsToCountryCmd = new SqlCommand(findAllTownsToCountryQuery, connection);
            findAllTownsToCountryCmd.Parameters.AddWithValue("@id", countryId);

            using var allCities = findAllTownsToCountryCmd.ExecuteReader();
            List<string> citiesAffected = new List<string>();
            while (allCities.Read())
            {
                string name = allCities["Name"]?.ToString();
                if (name != null)
                {
                    citiesAffected.Add(name);
                }
            }
            return citiesAffected;
        }
    }
}
