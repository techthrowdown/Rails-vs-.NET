using ProductDevelopment.Models;
using ProductDevelopment.Web.Models;

namespace ProductDevelopment.Web.Infrastructure.Data
{
    public interface IUserRepository : IRepository<User>
    {
        User FindByUsername(string username);
        bool ValidateUserCredentials(string username, string password);
    }
}