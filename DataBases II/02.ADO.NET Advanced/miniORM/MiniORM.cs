using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using miniORM.Entities;

namespace miniORM
{
    class MiniORM
    {
        static void Main(string[] args)
        {
            string connectionStr = new ConnectionStringBuilder("WebSiteData").ConnectionString(); 
            IDbContext dbContext = new EntityManager(connectionStr,true);

            User user = new User("Kosta","password",20,DateTime.Now);
            dbContext.Persist(user);
        }
    }
}
