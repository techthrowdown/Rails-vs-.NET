using ProductDevelopment.Models;

namespace ProductDevelopment.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        User FindByUsername(string username);
        bool ValidateUserCredentials(string username, string password);
    }
}