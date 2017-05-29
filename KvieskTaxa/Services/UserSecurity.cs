using KvieskTaxa.Database;
using KvieskTaxa.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace KvieskTaxa.Services
{
    public class UserSecurity : IUserSecurity
    {
        DataModelContext db;

        public UserSecurity(DataModelContext db)
        {
            this.db = db;
        }

        public string GenerateHashWithSalt(string password, string salt)
        {
            string sHashWithSalt = password + salt;
            byte[] saltedHashBytes = System.Text.Encoding.UTF8.GetBytes(sHashWithSalt);
            System.Security.Cryptography.HashAlgorithm algorithm = new System.Security.Cryptography.SHA256Managed();
            byte[] hash = algorithm.ComputeHash(saltedHashBytes);
            return Convert.ToBase64String(hash);
        }

        public string GenerateSaltValue()
        {
            UnicodeEncoding utf16 = new UnicodeEncoding();

            if (utf16 != null)
            {
                Random random = new Random(unchecked((int)DateTime.Now.Ticks));

                if (random != null)
                {
                    byte[] saltValue = new byte[40];
                    random.NextBytes(saltValue);
                    string saltValueString = utf16.GetString(saltValue);
                    return saltValueString;
                }
            }
            return null;
        }

        public User ValidateLogin(string username, string userpassword)
        {
            User data = db.Users.FirstOrDefault(x => x.username == username);
            if(data != null)
            {
                if (GenerateHashWithSalt(userpassword, data.Salt) == data.password)
                {
                    return data;
                }
                return null;
            }
            return null;
        }
    }
}