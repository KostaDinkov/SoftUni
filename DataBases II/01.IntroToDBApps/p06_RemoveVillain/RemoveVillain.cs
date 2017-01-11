using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace p06_RemoveVillain
{
    internal class RemoveVillain
    {
        private static void Main(string[] args)
        {
            var connectionStr = GetConnectionString();
            var villainID = int.Parse(Console.ReadLine());

            using (var connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                var transaction = connection.BeginTransaction("Remove Villain");
                var command = new SqlCommand();
                command.Connection = connection;
                command.Transaction = transaction;

                try
                {
                    //remove villain id from MinionVillain tbl and get the id's for the released minions

                    var villainName = GetVillainName(villainID, command);

                    if (string.IsNullOrEmpty(villainName))
                    {
                        Console.WriteLine("No such villain was found");
                    }
                    else
                    {
                        var freeMinions = GetFreeMinions(villainID, command);
                        var rowsAffected = DeleteVillainByID(villainID, command);
                        Console.WriteLine($"{villainName} was deleted");
                        Console.WriteLine($"{freeMinions.Length} minions released.");
                    }

                    //Console.WriteLine(string.Join(", ", freeMinions));

                    transaction.Commit();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("ROLLING BACK");
                    command.Transaction.Rollback();
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private static string GetVillainName(int villainId, SqlCommand command)
        {
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@villainID", villainId);
            command.CommandText = "select  Name from Villains where Id = @villainID";
            var result = command.ExecuteScalar();
            return result?.ToString() ?? string.Empty;
        }

        private static int DeleteVillainByID(int villainId, SqlCommand command)
        {
            command.CommandText =
                "delete from MinionsVillains where villainID = @villainID; delete from villains where ID = @villainID";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@villainID", villainId);
            var result = command.ExecuteNonQuery();
            return result;
        }

        private static string[] GetFreeMinions(int villainId, SqlCommand command)
        {
            command.CommandText = "select distinct m.Name from MinionsVillains mv " +
                                  "join Minions m on m.Id = mv.MinionId " +
                                  "where VillainID = @villainID";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@villainID", villainId);
            var table = new DataTable();
            table.Load(command.ExecuteReader());

            var results = (from row in table.AsEnumerable() select row["Name"].ToString()).ToArray();
            return results;
        }

        private static string GetConnectionString()
        {
            var stringBuilder = new SqlConnectionStringBuilder();
            stringBuilder.DataSource = "KOSTA-PC\\SOFTUNISQLSERVER";
            stringBuilder.InitialCatalog = "Minions";
            stringBuilder.IntegratedSecurity = true;
            return stringBuilder.ToString();
        }
    }
}