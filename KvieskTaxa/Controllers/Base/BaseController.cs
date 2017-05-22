using KvieskTaxa.Data.Users;
using System.Web.Mvc;

namespace KvieskTaxa.Controllers.Base
{
    public class BaseController : Controller
    {
        public BaseController()
        {

        }

        protected new virtual UserPrincipal User
        {
            get
            {
                if (HttpContext != null && HttpContext.User != null)
                {
                    return HttpContext.User as UserPrincipal;
                }

                return null;
            }
        }
    }
}