using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Books.Core.Repositories;

namespace Books.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IAuthorRepository Authors { get; }
        IBookRepository Books { get; }
        IGenreRepository Genres { get; }
        IStorageUnitRepository StorageUnits { get; }
        IUserRepository Users { get; }

        Task<int> CommitAsync();

    }
}
