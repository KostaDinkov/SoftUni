using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;

namespace p08_IncreaseMinionAge
{
    internal class IncreaseAge
    {
        private static void Main(string[] args)
        {
            var connectionStr = GetConnectionString();
            var minionIDs = Console.ReadLine().Split().Select(e => int.Parse(e)).ToArray();
            var myTI = CultureInfo.CurrentCulture.TextInfo;
            using (var connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                var sqlQuerry = string.Format("Select Id, Name, Age from Minions where id in ({0})",
                    string.Join(", ", minionIDs));

                var command = new SqlCommand(sqlQuerry, connection);

                try
                {
                    var ad = new SqlDataAdapter(command);
                    var table = new DataTable();
                    ad.Fill(table);
                    foreach (var dataRow in table.AsEnumerable())
                    {
                        dataRow["Name"] = myTI.ToTitleCase(dataRow["Name"].ToString());
                        dataRow["Age"] = int.Parse(dataRow["Age"].ToString()) + 1;
                        //Console.WriteLine($"{dataRow["Id"]}\t{dataRow["Name"]}\t{dataRow["Age"]}");
                    }

                    var builder = new SqlCommandBuilder(ad);
                    ad.UpdateCommand = builder.GetUpdateCommand();
                    ad.Update(table);

                    command.CommandText = "select * from Minions";
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                        Console.WriteLine($"{reader[0]}\t{reader[1]}\t{reader[2]}");
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