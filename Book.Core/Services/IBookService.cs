using Books.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Books.Core.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book> GetBookById(int id);
        Task CreateBook(Book book);
        IEnumerable<Book> GetBookByTitle(string name);
        Task MoveBook(Book book, StorageUnit storageUnit);
        Task DeleteBook(Book book);
        Task UpdateBook(Book book);

        Task<IEnumerable<Genre>> GetAllGenres();
        Task<Genre> GetGenreById(int id);
        IEnumerable<Genre> GetGenreByTitle(string name);
        Task CreateGenre(Genre genre);

        Task<IEnumerable<StorageUnit>> GetAllStorageUnitsAsync();
        Task<StorageUnit> GetStorageUnitById(int id);

    }
}
