using Books.Core;
using Books.Core.Repositories;
using Books.Data.Repositories;
using System.Threading.Tasks;
using Xamarin.Forms;

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

        public UnitOfWork()
        {
            _context = DependencyService.Get<LibraryDbContext>();
        }
        public UnitOfWork(LibraryDbContext context)
        {
            _context = context;
        }

        public IAuthorRepository Authors => authorRepository ??= new AuthorRepository(_context);

        public IBookRepository Books => bookRepository ??= new BookRepository(_context);

        public IGenreRepository Genres => genreRepository ??= new GenreRepository(_context);

        public IStorageUnitRepository StorageUnits => storageUnitRepository ??= new StorageUnitRepository(_context);

        public IUserRepository Users => userRepository ??= new UserRepository(_context);

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
