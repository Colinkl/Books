using Books.Core.Repositories;
using System;
using System.Threading.Tasks;

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
