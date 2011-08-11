using ProductDevelopment.Models;

namespace ProductDevelopment.Web.Infrastructure
{
    public interface IAuthentication
    {
        bool LogonUser(string username, string password, bool persistLogin);
        void LogoutUser();
        User CurrentUser();
    }
}