using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p09_IncreaseAgeSP
{
    class GetOlder
    {
        static void Main(string[] args)
        {
            string connectionString = GetConnectionString();


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    IncreaseMinionAge(connection);
                }
                
                finally
                {
                    connection.Close();
                }
                
            }

        }

        private static void IncreaseMinionAge(SqlConnection connection)
        {
            int minionID = int.Parse(Console.ReadLine());
            string sqlCommand = "exec usp_GetOlder @minionID";
            SqlCommand command = new SqlCommand(sqlCommand,connection);
            command.Parameters.AddWithValue("@minionID", minionID);
            command.ExecuteNonQuery();
            command.Dispose();

            printMinionWithID(connection, minionID);
        }

        private static void printMinionWithID(SqlConnection connection, int minionId)
        {
            string sqlQuery = "Select Name, Age from Minions where Id = @minionId";
            SqlCommand command = new SqlCommand(sqlQuery,connection);
            command.Parameters.AddWithValue("@minionId", minionId);
            SqlDataReader reader = command.ExecuteReader();

            reader.Read();
            Console.WriteLine($"{reader[0]} {reader[1]}");
            command.Dispose();

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
