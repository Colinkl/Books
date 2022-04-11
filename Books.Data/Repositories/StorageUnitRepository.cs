using Books.Core.Models;
using Books.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Books.Data.Repositories
{
    public class StorageUnitRepository : Repository<StorageUnit>, IStorageUnitRepository
    {
        public StorageUnitRepository(DbContext context)
        {
        }
    }
}
