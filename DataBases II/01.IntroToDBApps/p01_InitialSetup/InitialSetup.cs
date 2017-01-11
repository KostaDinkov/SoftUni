using System;
using System.Data.SqlClient;

namespace p01_InitialSetup
{
    internal class InitialSetup
    {
        private static void Main(string[] args)
        {
            var connStr = new SqlConnectionStringBuilder();
            connStr.DataSource = "KOSTA-PC\\SOFTUNISQLSERVER";
            connStr.IntegratedSecurity = true;
            var con = new SqlConnection(connStr.ToString());

            // create database
            var createDB = "create database Minions";
            using (con)
            {
                con.Open();
                ExecuteSqlCommand(createDB, con);
                con.Close();
            }
            connStr.InitialCatalog = "Minions";
            con = new SqlConnection(connStr.ToString());

            var createTownsTbl = "create table Towns (" +
                                 "Id int primary key identity, " +
                                 "Name varchar(50), " +
                                 "Country varchar(50))";

            var createMinionsTbl = "create table Minions " +
                                   "(Id int primary key identity, " +
                                   "Name varchar(50), " +
                                   "Age int, TownId int, " +
                                   "constraint FK_Towns foreign key (TownId) references Towns(Id))";

            var createVillainsTbl = "create table Villains " +
                                    "(Id int primary key identity, " +
                                    "Name varchar(50), " +
                                    "EvilnessFactor varchar(20))";

            var createMinionsVillainsTbl = "create table MinionsVillains" +
                                           "(MinionId INT, VillainId INT, " +
                                           "constraint FK_Minions foreign key (MinionId) references Minions(Id), " +
                                           "constraint  FK_Villains foreign key (VillainId) references Villains(Id))";

            var insertTowns = "insert into Towns (Name, Country) " +
                              "values ('Sofia','Bulgaria'), " +
                              "('Burgas','Bulgaria'), " +
                              "('Varna', 'Bulgaria'), " +
                              "('London','UK')," +
                              "('Liverpool','UK')," +
                              "('Ocean City','USA')," +
                              "('Paris','France')";

            var insertMinions = "insert into Minions (Name, Age, TownId) " +
                                "values ('bob',10,1)," +
                                "('kevin',12,2)," +
                                "('steward',9,3), " +
                                "('rob',22,3), " +
                                "('michael',5,2)," +
                                "('pep',3,2)";

            var insertVillains = "insert into Villains (Name, EvilnessFactor) " +
                                 "values ('Gru','super evil')," +
                                 "('Victor','evil')," +
                                 "('Simon Cat','good')," +
                                 "('Pusheen','super good')," +
                                 "('Mammal','evil')";

            var insertMinionsVillains = "insert into MinionsVillains " +
                                        "values (1,2), (3,1),(1,3),(3,3),(4,1),(2,2),(1,1),(3,4), (1, 4), (1,5), (5, 1), (4,1), (3, 1)";

            using (con)
            {
                try
                {
                    con.Open();
                    ExecuteSqlCommand(createTownsTbl, con);
                    ExecuteSqlCommand(createMinionsTbl, con);
                    ExecuteSqlCommand(createVillainsTbl, con);
                    ExecuteSqlCommand(createMinionsVillainsTbl, con);
                    ExecuteSqlCommand(insertTowns, con);
                    ExecuteSqlCommand(insertMinions, con);
                    ExecuteSqlCommand(insertVillains, con);
                    ExecuteSqlCommand(insertMinionsVillains, con);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private static void ExecuteSqlCommand(string commandText, SqlConnection connection)
        {
            var command = new SqlCommand(commandText, connection);
            command.ExecuteNonQuery();
        }
    }
}