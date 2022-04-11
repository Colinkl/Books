using Books.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Books.Core.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book> GetBookById(int id);
        IEnumerable<Book> GetBookByTitle(string name);
        Task MoveBook(Book book, StorageUnit storageUnit);
        Task DeleteBook(Book book);
        Task UpdateBook(Book book);

    }
}
