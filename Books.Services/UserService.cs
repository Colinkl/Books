using Books.Core;
using Books.Core.Models;
using Books.Core.Services;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Books.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;

        public UserService()
        {
            unitOfWork = DependencyService.Get<IUnitOfWork>();
        }

        public Task<User> LoginUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task LogOutUser()
        {
            throw new NotImplementedException();
        }

        public Task<User> RegisterUser(User newUser)
        {
            throw new NotImplementedException();
        }
    }
}
