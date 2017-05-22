using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace KvieskTaxa.Data.Users
{
    public class UserPrincipal : IUserPrincipal
    {
        public UserPrincipal(string username)
        {
            Identity = new GenericIdentity(username);
        }

        public IIdentity Identity { get; }

        public int Status { get; set; }

        public int UserId { get; set; }

        public string Username { get; set; }

        public bool IsInRole(string role)
        {
            return ((UserPrincipal)HttpContext.Current.User).Status.ToString() == role ? true: false;
        }
    }
}