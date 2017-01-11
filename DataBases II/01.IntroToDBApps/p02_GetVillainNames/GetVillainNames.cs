using System;
using System.Data.SqlClient;

namespace p02_GetVillainNames
{
    internal class GetVillainNames
    {
        private static void Main(string[] args)
        {
            var connectionStr = new SqlConnectionStringBuilder();
            connectionStr.DataSource = "KOSTA-PC\\SOFTUNISQLSERVER";
            connectionStr.InitialCatalog = "Minions";
            connectionStr.IntegratedSecurity = true;

            var connection = new SqlConnection(connectionStr.ToString());

            using (connection)
            {
                connection.Open();

                var command = new SqlCommand();
                command.CommandText = "select Name, COUNT(mv.MinionId) from Villains v " +
                                      "join MinionsVillains mv on mv.VillainId = v.Id " +
                                      "group by v.Name " +
                                      "order by COUNT(mv.MinionId) desc";

                command.Connection = connection;

                using (var dataReader = command.ExecuteReader())
                {
                    var columnCount = dataReader.FieldCount;
                    while (dataReader.Read())
                    {
                        for (var i = 0; i < columnCount; i++)
                        {
                            Console.Write(dataReader[i] + "\t");
                        }
                        Console.WriteLine();
                    }
                }
                connection.Close();
            }
        }
    }
}