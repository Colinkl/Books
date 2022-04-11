using Books.Core.Models;
using Books.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Books.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext context)
        {
        }
    }
}
