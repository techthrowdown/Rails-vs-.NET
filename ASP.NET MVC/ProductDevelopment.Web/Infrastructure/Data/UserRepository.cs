using System;
using System.Linq;
using System.Web.Helpers;
using ProductDevelopment.Web.Models;

namespace ProductDevelopment.Web.Infrastructure.Data
{
    public class UserRepository : Repository<User>, IUserRepository
    {
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

        public override void Add(User entity)
        {
            entity.Password = Crypto.HashPassword(entity.Password);
            base.Add(entity);
        }

        private bool VerifyHashedPassword(string hashedPassword, string plainTextPassword)
        {
            return Crypto.VerifyHashedPassword(hashedPassword, plainTextPassword);
        }
    }
}