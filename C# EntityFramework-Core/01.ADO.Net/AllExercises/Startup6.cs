using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace EntityFrameworkCore_ADO.NET_exercise
{
    class MyEx
    {
        [DataType("nvarchar(30)")];
        public string Name { get; set; }
        public void TestMethod()
        {
            using (SqlConnection sqlConnection = new SqlConnection(@"Server = .\SQLEXPRESS;Database = MinionsDBB;Integrated Security=true"))
            {
                sqlConnection.Open();
                int id = int.Parse(Console.ReadLine());
                SqlCommand checkCommand = new SqlCommand("SELECT Count(*) FROM Villains WHERE Id = @id", sqlConnection);
                checkCommand.Parameters.AddWithValue("@id", id);
                int numberOfVillains = (int)checkCommand.ExecuteScalar();
                if (numberOfVillains == 0)
                {
                    Console.WriteLine($"No villain with ID < {id} > exists in the database.");
                    return;
                }
                SqlCommand checkMinions = new SqlCommand("SELECT  COUNT(m.Name) FROM Villains AS v " +

                "LEFT JOIN MinionsVillains AS mv ON v.Id = mv.VillainId " +

                "LEFT JOIN Minions AS m ON mv.MinionId = m.Id " +

               "WHERE v.Id = @id", sqlConnection);
                checkMinions.Parameters.AddWithValue("@id", id);
                int numberOfMinions = (int)checkMinions.ExecuteScalar();

                SqlCommand command = new SqlCommand(
                    "SELECT * FROM Villains AS v " +

                    "LEFT OUTER JOIN MinionsVillains AS mv ON v.Id = mv.VillainId " +

                    "LEFT OUTER JOIN Minions AS m ON mv.MinionId = m.Id " +

                    "WHERE v.Id = @id", sqlConnection);

                command.Parameters.AddWithValue("@id", id);


                Dictionary<string, int?> minions = new Dictionary<string, int?>();
                using (var villain = command.ExecuteReader())
                {
                    villain.Read();
                    string villainName = (string)villain["Name"];
                    int? age = villain["Age"] as int?;
                    minions.Add(villainName, age);

                    if (numberOfMinions == 0)
                    {
                        Console.WriteLine($"Villain: {villainName}(no minions)");
                        return;
                    }

                    Console.WriteLine($"Villain: {villainName}:");
                    while (villain.Read())
                    {
                        string minion = (string)villain[6];
                        age = (int)villain["Age"];
                        minions.Add(minion, age);
                    }

                    int index = 1;
                    StringBuilder sb = new StringBuilder();
                    foreach (var item in minions.OrderBy(x => x.Key))
                    {
                        sb.AppendLine($"{index}. " + $"{item.Key} " + $"{item.Value}");
                        index++;
                    }
                    Console.WriteLine(sb.ToString());

                }
            }
        }
    }
}
