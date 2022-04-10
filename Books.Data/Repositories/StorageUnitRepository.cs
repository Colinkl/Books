using Books.Core.Models;
using Books.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Books.Data.Repositories
{
    public class StorageUnitRepository : Repository<StorageUnit>, IStorageUnitRepository
    {
        public StorageUnitRepository(DbContext context) : base(context)
        {
        }
    }
}
