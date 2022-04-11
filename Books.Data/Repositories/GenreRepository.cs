using Books.Core.Models;
using Books.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Books.Data.Repositories
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        public GenreRepository(DbContext context)
        {
        }
    }
}
