using ProductDevelopment.Models;
using ProductDevelopment.Web.Models;

namespace ProductDevelopment.Web.Infrastructure.Security
{
    public interface IAuthentication
    {
        bool LogonUser(string username, string password, bool persistLogin);
        void LogoutUser();
        UserToken CurrentUser();
    }
}