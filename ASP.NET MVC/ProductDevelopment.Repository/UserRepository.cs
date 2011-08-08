using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Helpers;
using ProductDevelopment.Models;

namespace ProductDevelopment.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IProductDevelopmentContext ctx) : base(ctx)
        {
            
        }

        public User FindByUsername(string username)
        {
            return _ctx.Users.Where(u => u.Username.ToLower() == username.ToLower()).SingleOrDefault();
        }

        public bool ValidateUserCredentials(string username, string password)
        {
            var user = FindByUsername(username);
            if (user != null)
            {
                if (VerifyHashedPassword(user.Password, password))
                {
                    return true;
                }
            }
            return false;
        }

        private bool VerifyHashedPassword(string hashedPassword, string plainTextPassword)
        {
            return Crypto.VerifyHashedPassword(hashedPassword, plainTextPassword);
        }
    }
}
