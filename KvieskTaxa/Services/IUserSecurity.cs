using KvieskTaxa.Database.Models;

namespace KvieskTaxa.Services
{
    public interface IUserSecurity
    {
        string GenerateHashWithSalt(string password, string salt);

        string GenerateSaltValue();

        User ValidateLogin(string username, string userpassword);
    }
}
