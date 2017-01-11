using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace p07_PrintMinionNames
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var connectionStr = GetConnectionString();

            using (var connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                var sqlQuerry = "select Name from Minions";
                var command = new SqlCommand(sqlQuerry, connection);

                var table = new DataTable();

                try
                {
                    table.Load(command.ExecuteReader());
                    var minionNames = (from row in table.AsEnumerable() select row["Name"].ToString()).ToArray();
                    PrintNames(minionNames);
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

        private static void PrintNames(string[] minionNames)
        {
            Console.WriteLine(string.Join("\n", minionNames));
            Console.WriteLine();
            var namesCount = minionNames.Length;

            //dont repeat the Name in the middle of the list, when there are odd number of elements in it
            for (var i = 0; i <= namesCount / 2; i++)
            {
                Console.WriteLine(minionNames[i]);
                if (namesCount - 1 - i != i)
                    Console.WriteLine(minionNames[namesCount - 1 - i]);
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