using Books.Core.Models;
using Books.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Books.Data.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(LibraryDbContext context) : base(context)
        {

        }
    }
}
