using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace EF___ADO.NET___exercise3
{
    class Program
    {
        private const string connectionStringOne = @"Server = .\SQLEXPRESS;Database = MinionsDBB;Integrated Security = true;";
        private const string connectionStringTwo = @"Server = .\SQLEXPRESS;Database = Diablo;Integrated Security = true;";
        static void Main(string[] args)
        {
            string[] minionInfo = Console.ReadLine().Split(new char[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string minionName = minionInfo[1];
            int minionAge = int.Parse(minionInfo[2]);
            string minionTown = minionInfo[3];

            string[] villainInfo = Console.ReadLine().Split(new char[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string villainName = villainInfo[1];


            using SqlConnection connection = new SqlConnection(connectionStringOne);
            connection.Open();
            try
            {


                string town = GetTownInfo(minionTown, connection);

                string villain = GetVillainInfo(connection, villainName);

                if (town == null)
                {
                    InsertTownIntoDb(minionTown, connection);
                }

                if (villain == null)
                {
                    InsertVillainIntoDb(villainName, connection);
                }


                int townId = FindTownId(connection, minionTown);

                int villainId = FindVillainId(connection, villainName);
              
                InsertMinionIntoDb(minionName, minionAge, connection, townId);

                int minionId = FindMinionId(connection, minionName, minionAge, townId);

                InsertMinionToVillain(connection, villainId, minionId);


                Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
            }
            catch (Exception)
            {
                connection.Close();
                using SqlConnection restoreConnection = new SqlConnection(connectionStringTwo);
                restoreConnection.Open();
                SqlCommand commandRestore = new SqlCommand("EXECUTE [dbo].[BackUpDatabase]", restoreConnection);
                commandRestore.ExecuteNonQuery();
            }

        }

        private static void InsertMinionToVillain(SqlConnection connection, int villainId, int minionId)
        {
            string insertMinionToVillainQuery = @"INSERT INTO MinionsVillains (MinionId,VillainId) VALUES (@minionId,@villainId)";
            SqlCommand insertMinionToVillain = new SqlCommand(insertMinionToVillainQuery, connection);

            insertMinionToVillain.Parameters.AddWithValue("@minionId", minionId);
            insertMinionToVillain.Parameters.AddWithValue("@villainId", villainId);

            insertMinionToVillain.ExecuteNonQuery();

        }

        private static void InsertVillainIntoDb(string villainName, SqlConnection connection)
        {
            string insertVillainInDbQuery = @"INSERT INTO Villains ([Name],EvilnessFactorId) VALUES (@name,4)";
            SqlCommand insertVillainInDbCmd = new SqlCommand(insertVillainInDbQuery, connection);
            insertVillainInDbCmd.Parameters.AddWithValue("@name", villainName);
            insertVillainInDbCmd.ExecuteNonQuery();
            Console.WriteLine($"Villain {villainName} was added to the database.");
        }

        private static string GetVillainInfo(SqlConnection connection, string villainName)
        {
            string getVillainInfoQuery = @"Select Name FROM Villains WHERE Name = @name";
            SqlCommand getVillainInfoCommand = new SqlCommand(getVillainInfoQuery, connection);
            getVillainInfoCommand.Parameters.AddWithValue("@name", villainName);
            string villainInfo = getVillainInfoCommand.ExecuteScalar()?.ToString();
            return villainInfo;
        }
        private static int FindMinionId(SqlConnection connection, string minionName, int minionAge, int townId)
        {
            string findMinionIdQuery = @"SELECT Id FROM Minions WHERE Name = @minionName AND Age = @age AND TownId = @townId";
            SqlCommand findMinionCommand = new SqlCommand(findMinionIdQuery, connection);
            findMinionCommand.Parameters.AddWithValue("@minionName", minionName);
            findMinionCommand.Parameters.AddWithValue("@age", minionAge);
            findMinionCommand.Parameters.AddWithValue("@townId", townId);
            int minionId = (int)findMinionCommand.ExecuteScalar();
            return minionId;
        }
        private static int FindVillainId(SqlConnection connection, string villainName)
        {
            string villainIdQuery = @"SELECT Id FROM Villains WHERE [Name] = @villainName";
            SqlCommand findVillainId = new SqlCommand(villainIdQuery, connection);
            findVillainId.Parameters.AddWithValue("@villainName", villainName);
            int villainId = (int)findVillainId.ExecuteScalar();
            return villainId;
        }
        private static void InsertMinionIntoDb(string minionName, int minionAge, SqlConnection connection, int townId)
        {
            string insertMinionQuery = @"INSERT INTO Minions ([Name],Age,TownId) VALUES (@name,@age,@townId)";
            SqlCommand insertMinion = new SqlCommand(insertMinionQuery, connection);
            insertMinion.Parameters.AddWithValue("@name", minionName);
            insertMinion.Parameters.AddWithValue("@age", minionAge);
            insertMinion.Parameters.AddWithValue("@townId", townId);
            insertMinion.ExecuteNonQuery();
        }

        private static int FindTownId(SqlConnection connection, string townName)
        {
            string getTownId = @"SELECT Id FROM Towns WHERE [Name] = @townName";
            SqlCommand getTownIdCommand = new SqlCommand(getTownId, connection);
            getTownIdCommand.Parameters.AddWithValue("@townName", townName);
            int townId = (int)getTownIdCommand.ExecuteScalar();
            return townId;
        }

        private static void InsertTownIntoDb(string minionTown, SqlConnection connection)
        {
            string newTownQuery = @"INSERT INTO Towns ([Name],CountryCode) VALUES (@newtown,NULL)";
            SqlCommand dbAddTown = new SqlCommand(newTownQuery, connection);
            dbAddTown.Parameters.AddWithValue("@newTown", minionTown);
            dbAddTown.ExecuteNonQuery();
            Console.WriteLine($"Town {minionTown} was added to the database.");
        }

        private static string GetTownInfo(string minionTown, SqlConnection connection)
        {
            string townQuery = @"SELECT [Name] FROM Towns WHERE Name = @town";

            SqlCommand dbTownInfo = new SqlCommand(townQuery, connection);
            dbTownInfo.Parameters.AddWithValue("@town", minionTown);
            string currentTown = dbTownInfo.ExecuteScalar()?.ToString();
            return currentTown;
        }
    }
}
