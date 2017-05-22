using System.Web.Mvc;
using KvieskTaxa.Database.Models;
using KvieskTaxa.Database;
using System.Linq;
using System.Web.Security;
using KvieskTaxa.Models;
using KvieskTaxa.Controllers.Base;
using System.Web.Script.Serialization;
using System;
using System.Web;

namespace KvieskTaxa.Controllers
{
    public class UsersController : BaseController
    {
        private DataModelContext db;

        public UsersController()
        {
            db = new DataModelContext();
        }

        public ActionResult Login()
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Administrator", new { area = "Administrator" });
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(User model)
        {
            if (ModelState.IsValid)
            {
                User user = db.Users.FirstOrDefault(x => x.username == model.username);
                if(user != null)
                {
                    if (user.password == model.password)
                    {
                        AuthenticationData(user);
                        if (user.Administrator != null)
                            return RedirectToAction("Index", "Administrator", new { area = "Administrator" });
                        else if(user.Driver != null)
                            return RedirectToAction("Index", "Driver", new { area = "Driver" });
                        else if(user.Client != null)
                            return RedirectToAction("Index", "Client", new { area = "Client" });
                    }
                    ModelState.AddModelError("", "Neteisingi prisijungimo duomenys");
                    return View(model);
                }
                ModelState.AddModelError("", "Neteisingi prisijungimo duomenys");
                return View(model);
            }
            ModelState.AddModelError("", "Neteisingi įvesti duomenys");
            return View(model);
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Users");
        }

        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                User user = db.Users.FirstOrDefault(x => x.username == User.Username);
                if (user != null)
                {
                    if (user.password == model.OldPassword)
                    {
                        user.password = model.ConfirmPassword;
                        db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Logout");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Neteisingas senas vartotojo slaptažodis");
                        return View(model);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Neautorizuotas prisijungimas");
                    return View(model);
                }
            }
            return View(model);
        }

        private void AuthenticationData(User user)
        {
            UserWrapper usw = new UserWrapper();
            usw.UserId = user.UserId;
            usw.username = user.username;
            usw.Status = user.Status;

            JavaScriptSerializer serializer = new JavaScriptSerializer();

            string userData = serializer.Serialize(usw);

            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
            1,
            user.username,
            DateTime.Now,
            DateTime.Now.AddMinutes(20),
            false,
            userData);

            string encTicket = FormsAuthentication.Encrypt(authTicket);
            HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
            Response.Cookies.Add(faCookie);
        }
    }
}