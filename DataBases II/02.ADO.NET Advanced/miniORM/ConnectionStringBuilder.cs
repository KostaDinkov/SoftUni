using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniORM
{
    class ConnectionStringBuilder
    {
        private SqlConnectionStringBuilder sqlConnectionSb { get; }

        public ConnectionStringBuilder(string dataBaseName)
        {
            this.sqlConnectionSb = new SqlConnectionStringBuilder();
            this.sqlConnectionSb.DataSource = "KOSTA-PC\\SOFTUNISQLSERVER";
            this.sqlConnectionSb.IntegratedSecurity = true;
            this.sqlConnectionSb.ConnectTimeout = 1000;
            this.sqlConnectionSb.InitialCatalog = dataBaseName;

        }

        public string ConnectionString()
        {
            return this.sqlConnectionSb.ToString();
        }


    }
}
