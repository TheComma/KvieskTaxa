using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace KvieskTaxa.Data.Users
{
    public interface IUserPrincipal : IPrincipal
    {
        int UserId { get; set; }
        
        string Username { get; set; }

        int Status { get; set; }
    }
}
