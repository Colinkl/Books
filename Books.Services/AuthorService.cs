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
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork unitOfWork;

        public AuthorService()
        {
            unitOfWork = DependencyService.Get<IUnitOfWork>();
        }

        public AuthorService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task CreateAuthor(Author newAuthor)
        {
            await unitOfWork.Authors.AddAsync(newAuthor);
        }

        public async Task DeleteAuthor(Author Author)
        {
            unitOfWork.Authors.Remove(Author);
            await unitOfWork.CommitAsync();
        }

        public IEnumerable<Author> FindAuthorByName(string name)
        {
            Expression<Func<Author, bool>> f = (p => p.Name.Contains(name));
            return unitOfWork.Authors.Find(f);
        }


        public async Task<IEnumerable<Author>> GetAllAuthors()
        {
            return await unitOfWork.Authors.GetAllAsync();
        }

        public async Task<Author> GetAuthorById(int id)
        {
            return await unitOfWork.Authors.GetByIdAsync(id);
        }

        public async Task UpdateAuthor(Author AuthorToBeUpdated)
        {
            unitOfWork.Authors.UpdateAsync(AuthorToBeUpdated);
            await unitOfWork.CommitAsync();
        }
    }
}
