using System;
using System.Data;
using System.Data.SqlClient;

namespace p05_ChangeTownNameCasing
{
    internal class TownNameCasing
    {
        private static void Main(string[] args)
        {
            var connectionString = GetConnectionString();
            var country = Console.ReadLine();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand();

                command.CommandText = "update Towns " +
                                      "set [Name] = upper([Name]) " +
                                      "where Country = @country;";
                command.Parameters.AddWithValue("@country", country);
                command.Connection = connection;
                try
                {
                    var rowsChanged = command.ExecuteNonQuery();
                    if (rowsChanged == 0)
                    {
                        Console.WriteLine("No town names were affected.");
                    }
                    else
                    {
                        Console.WriteLine($"{rowsChanged} town names were affected");
                        command.CommandText = "select [Name] from Towns where Country = @country";

                        //get the results into datatable
                        var dataReader = command.ExecuteReader();
                        var table = new DataTable();
                        table.Load(dataReader);

                        var townsByCountry = from row in table.AsEnumerable() select row["Name"];
                        Console.WriteLine("[" + string.Join(", ", townsByCountry) + "]");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
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