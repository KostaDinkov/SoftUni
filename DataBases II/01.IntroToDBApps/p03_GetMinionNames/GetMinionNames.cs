using System;
using System.Data;
using System.Data.SqlClient;

namespace p03_GetMinionNames
{
    internal class GetMinionNames
    {
        private static void Main(string[] args)
        {
            var connectionStr = new SqlConnectionStringBuilder();
            connectionStr.DataSource = "KOSTA-PC\\SOFTUNISQLSERVER";
            connectionStr.InitialCatalog = "Minions";
            connectionStr.IntegratedSecurity = true;

            var connection = new SqlConnection(connectionStr.ToString());

            var villainID = int.Parse(Console.ReadLine());
            var sqlQuerry = "select DiSTINCT v.Name, m.Name, m.Age from Villains v " +
                            "join MinionsVillains mv on mv.VillainId = v.Id " +
                            "join Minions m on m.Id = mv.MinionId " +
                            "where v.Id=@villainID;";
            try
            {
                using (connection)
                {
                    connection.Open();

                    var command = new SqlCommand(sqlQuerry, connection);
                    command.Parameters.AddWithValue("@villainID", villainID);
                    var dataTable = new DataTable();
                    var adapter = new SqlDataAdapter(command);

                    adapter.Fill(dataTable);
                    if (dataTable.Rows.Count > 0)
                    {
                        var villainName = dataTable.Rows[0][0].ToString();
                        Console.WriteLine($"Villain: {villainName}");
                        var rowCounter = 1;
                        foreach (DataRow row in dataTable.Rows)
                        {
                            Console.WriteLine($"{rowCounter}. {row[1]} {row[2]}");
                            rowCounter++;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"No villain with ID {villainID} exists in the database.");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}