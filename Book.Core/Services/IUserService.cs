using Books.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Books.Core.Services
{
    public interface IUserService
    {
        Task<User> RegisterUser(User newUser);
        Task<User> LoginUser(string username, string password);
        Task LogOutUser();




    }
}
