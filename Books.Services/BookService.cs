﻿using Books.Core;
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

        public async Task DeleteBook(Book book)
        {
            unitOfWork.Books.Remove(book);
            await unitOfWork.CommitAsync();
        }


        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await unitOfWork.Books.GetAllAsync();
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

        public async Task MoveBook(Book book, StorageUnit storageUnit)
        {
            book.Location = storageUnit;
            await unitOfWork.CommitAsync();
        }

        public Task UpdateBook(Book book)
        {
            throw new NotImplementedException();
        }
    }
}