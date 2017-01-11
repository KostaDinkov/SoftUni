using System;
using System.Data.SqlClient;

namespace p04_AddMinion
{
    internal class AddMinion
    {
        private static void Main(string[] args)
        {
            var connectionStr = new SqlConnectionStringBuilder();
            connectionStr.DataSource = "KOSTA-PC\\SOFTUNISQLSERVER";
            connectionStr.InitialCatalog = "Minions";
            connectionStr.IntegratedSecurity = true;


            SqlTransaction transaction;
            //read input
            var minionInput = Console.ReadLine().Split(':')[1];
            var minionParams = minionInput.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            var minionName = minionParams[0].Trim();
            var minionAge = int.Parse(minionParams[1]);
            var minionTown = minionParams[2];


            var villainName = Console.ReadLine().Split(':')[1].Trim();


            using (var connection = new SqlConnection(connectionStr.ToString()))
            {
                connection.Open();
                transaction = connection.BeginTransaction("SampleTransaction");
                var command = connection.CreateCommand();
                command.Transaction = transaction;
                command.Connection = connection;
                try
                {
                    insertMinion(minionName, minionAge, minionTown, villainName, command);
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    transaction.Rollback();
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private static void insertMinion(string minionName, int minionAge, string minionTown, string villainName,
            SqlCommand command)
        {
            checkTown(minionTown, command);
            checkVillain(villainName, command);

            command.Parameters.Clear();
            command.CommandText =
                "insert into Minions (Name, Age, TownID) values (@minionName, @minionAge, (select top 1 Id from Towns where Name = @minionTown))";
            command.Parameters.AddWithValue("@minionTown", minionTown);
            command.Parameters.AddWithValue("@minionName", minionName);
            command.Parameters.AddWithValue("@minionAge", minionAge);
            command.Parameters.AddWithValue("@villainName", villainName);

            var minionsVillainsSql = "insert into MinionsVillains " +
                                     "values " +
                                     "((select top 1 m.ID from Minions m where m.Name = @minionName)," +
                                     "(select top 1 v.Id from Villains v where v.Name = @villainName));";


            try
            {
                if (command.ExecuteNonQuery() > 0)
                {
                    Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}");
                    command.CommandText = minionsVillainsSql;
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Error while inserting minion");
                command.Transaction.Rollback();
                throw;
            }
        }

        private static void checkVillain(string villainName, SqlCommand command)
        {
            command.CommandText = "if not exists (select name from Villains where name = @villainName) " +
                                  "begin insert into Villains (Name, EvilnessFactor) values (@villainName,'evil') end";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@villainName", villainName);
            try
            {
                if (command.ExecuteNonQuery() > 0)
                {
                    Console.WriteLine($"Villain {villainName} was added to the database.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while checking villain");
                Console.WriteLine(e.Message);
                command.Transaction.Rollback();
                throw;
            }
        }

        private static void checkTown(string minionTown, SqlCommand command)
        {
            command.CommandText = "if not exists " +
                                  "(select Name from Towns where Name = @minionTown) " +
                                  "begin insert into Towns (Name) values (@minionTown) end";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@minionTown", minionTown);
            try
            {
                if (command.ExecuteNonQuery() > 0)
                {
                    Console.WriteLine($"Town {minionTown} was added to the database.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while checking town");
                Console.WriteLine(e.Message);
                command.Transaction.Rollback();
                throw;
            }
        }
    }
}