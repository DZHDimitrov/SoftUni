using System;
using System.Data.SqlClient;
using System.Text;

namespace EF___ADO.NET_exercise6
{
    class Program
    {
        private const string connectionStringOne = @"Server = .\SQLEXPRESS;Database = MinionsDBB;Integrated Security = true;";
        static void Main(string[] args)
        {
            using SqlConnection connection = new SqlConnection(connectionStringOne);
            connection.Open();
            SqlTransaction sqlTran = connection.BeginTransaction();
            SqlCommand command = connection.CreateCommand();
            command.Transaction = sqlTran;

            int id = int.Parse(Console.ReadLine());

            string villainName = GetVillainInfo(connection, id,sqlTran);
            if (villainName == null)
            {
                Console.WriteLine("No such villain was found.");
            }
            else
            {
                try
                {
                    
                    int countOfMinions = RemoveVillain(connection, id, villainName,sqlTran);
                    sqlTran.Commit();
                    Console.WriteLine($"{villainName} was deleted.");
                    Console.WriteLine($"{countOfMinions} minions were released.");
                }
                catch (Exception e)
                {
                    try
                    {
                        sqlTran.Rollback();
                        Console.WriteLine(e.Message);
                    }
                    catch (Exception rollback)
                    {
                        Console.WriteLine(rollback.Message);
                    }
                    
                }
                
            }
        }

        /// <summary>
        /// Finds the count of Minions being held by every Villain and releases them. Deletes the Villain.
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="id"></param>
        /// <param name="villainName"></param>
        /// <returns></returns>
        private static int RemoveVillain(SqlConnection connection, int id,string villainName,SqlTransaction sqlTran)
        {
            string findCountOfMinionsQuery = @"SELECT COUNT(MinionId) FROM MinionsVillains AS mv WHERE mv.VillainId = @villainId GROUP BY mv.VillainId";

            SqlCommand findCountOfMinions = new SqlCommand(findCountOfMinionsQuery, connection);
            findCountOfMinions.Transaction = sqlTran;
            findCountOfMinions.Parameters.AddWithValue("@villainId", id);
            int? countOfMinions = (int?)findCountOfMinions.ExecuteScalar();

            string deleteFromMinionsVilliansQuery = @"DELETE FROM MinionsVillains WHERE VillainId = @id";
            SqlCommand deleteFromMinionsVillians = new SqlCommand(deleteFromMinionsVilliansQuery, connection);
            deleteFromMinionsVillians.Transaction = sqlTran;
            deleteFromMinionsVillians.Parameters.AddWithValue("@id", id);
            deleteFromMinionsVillians.ExecuteNonQuery();

            string deleteFromVillainsQuery = $"DELETE FROM Villains WHERE Id = @id";
            SqlCommand deleteFromVillains = new SqlCommand(deleteFromVillainsQuery, connection);
            deleteFromVillains.Transaction = sqlTran;
            deleteFromVillains.Parameters.AddWithValue("@id", id);
            deleteFromVillains.ExecuteNonQuery();
            countOfMinions = (countOfMinions == null) ? 0 : countOfMinions;

            return (int)countOfMinions;

        }

        public static string GetVillainInfo(SqlConnection connection, int id,SqlTransaction sqlTran)
        {
            string villainExistQuery = @"SELECT [Name] FROM Villains WHERE Id = @id";
            SqlCommand command = new SqlCommand(villainExistQuery, connection);
            command.Transaction = sqlTran;
            command.Parameters.AddWithValue("@id", id);
            var villainName = command.ExecuteScalar()?.ToString();

            return villainName;
        }
    }
}
