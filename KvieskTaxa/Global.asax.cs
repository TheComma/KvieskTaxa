using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Web.Security;
using KvieskTaxa.Data.Users;
using KvieskTaxa.Models;

namespace KvieskTaxa
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
		}

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                JavaScriptSerializer serializer = new JavaScriptSerializer();

                UserWrapper serializeModel = serializer.Deserialize<UserWrapper>(authTicket.UserData);

                if (serializeModel != null)
                {
                    UserPrincipal newUser = new UserPrincipal(authTicket.Name);
                    newUser.UserId = serializeModel.UserId;
                    newUser.Username = serializeModel.username;
                    newUser.Status = serializeModel.Status;

                    HttpContext.Current.User = newUser;
                }
            }
        }
    }
}
