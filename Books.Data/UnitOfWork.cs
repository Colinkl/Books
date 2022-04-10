using Books.Core;
using Books.Core.Repositories;
using Books.Data.Repositories;
using System;
using System.Threading.Tasks;

namespace Books.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryDbContext _context;
        private AuthorRepository authorRepository;
        private BookRepository bookRepository;
        private GenreRepository genreRepository;
        private StorageUnitRepository storageUnitRepository;
        private UserRepository userRepository;

        public UnitOfWork(LibraryDbContext context)
        {
            _context = context;
        }

        public IAuthorRepository Authors => authorRepository = authorRepository ?? new AuthorRepository(_context);

        public IBookRepository Books => bookRepository = bookRepository ?? new BookRepository(_context);

        public IGenreRepository Genres =>genreRepository = genreRepository ?? new GenreRepository(_context);

        public IStorageUnitRepository StorageUnits => storageUnitRepository = storageUnitRepository ?? new StorageUnitRepository(_context);

        public IUserRepository Users => userRepository = userRepository ?? new UserRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
