using GringotsDB.Core.Models;
using GringotsDB.Core.Repository;

namespace GringotsDB.Persistance.Repositories
{
    class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(GringotsDB context) : base(context)
        {
        }
    }
}