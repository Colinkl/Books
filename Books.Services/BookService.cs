using Books.Core;
using Books.Core.Models;
using Books.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Books.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork unitOfWork;
        public BookService()
        {
            unitOfWork = DependencyService.Get<IUnitOfWork>();
        }

        public IEnumerable<Book> BookSearch(string query)
        {
           return  unitOfWork.Books.BookSearch(query);
            
        }

        public async Task CreateBook(Book book)
        {
            await unitOfWork.Books.AddAsync(book);
            await unitOfWork.CommitAsync();
        }

        public async Task CreateGenre(Genre genre)
        {
            await unitOfWork.Genres.AddAsync(genre);
            await unitOfWork.CommitAsync();
        }

        public async Task DeleteBook(Book book)
        {
            unitOfWork.Books.Remove(book);
            await unitOfWork.CommitAsync();
        }


        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await unitOfWork.Books.GetAllAsync();
        }

        public async Task<IEnumerable<Genre>> GetAllGenres()
        {
            return await unitOfWork.Genres.GetAllAsync();
        }

        public async Task<IEnumerable<StorageUnit>> GetAllStorageUnitsAsync()
        {
            return await unitOfWork.StorageUnits.GetAllAsync();
        }

        public async Task<Book> GetBookById(int id)
        {
            return await unitOfWork.Books.GetByIdAsync(id);
        }

        public IEnumerable<Book> GetBookByTitle(string name)
        {
            Expression<Func<Book, bool>> f = (p => p.Title.StartsWith(name));
            return unitOfWork.Books.Find(f);
        }

        public async Task<Genre> GetGenreById(int id)
        {
            return await unitOfWork.Genres.GetByIdAsync(id);
        }

        public IEnumerable<Genre> GetGenreByTitle(string name)
        {
            Expression<Func<Genre, bool>> f = (p => p.Name.StartsWith(name));
            return unitOfWork.Genres.Find(f);
        }

        public async Task<StorageUnit> GetStorageUnitById(int id)
        {
           return await unitOfWork.StorageUnits.GetByIdAsync(id);
        }

        public async Task MoveBook(Book book, StorageUnit storageUnit)
        {
            book.Location = storageUnit;
            await unitOfWork.CommitAsync();
        }

        public Task UpdateBook(Book book)
        {
            unitOfWork.Books.UpdateBook(book);
            return Task.CompletedTask;
        }
    }
}
