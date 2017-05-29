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
using KvieskTaxa.Services;

namespace KvieskTaxa.Controllers
{
    public class UsersController : BaseController
    {
        private DataModelContext db;
        private UserSecurity us;

        public UsersController()
        {
            db = new DataModelContext();
            us = new UserSecurity(db);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Login()
        {
            if (Request.IsAuthenticated)
            {
                if (User.Status == 1)
                {
                    return RedirectToAction("Index", "Administrator", new { area = "Administrator" });
                }
                else if (User.Status == 2)
                {
                    return RedirectToAction("Index", "Driver", new { area = "Driver" });
                }
                else if (User.Status == 3)
                {
                    return RedirectToAction("Index", "Client", new { area = "Client" });
                }
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User model)
        {
            if (ModelState.IsValid)
            {
                    var user = us.ValidateLogin(model.username, model.password);
                    if (user != null)
                    {
                        AuthenticationData(user);
                        if (user.Status == 1)
                            return RedirectToAction("Index", "Administrator", new { area = "Administrator" });
                        else if(user.Status == 2)
                            return RedirectToAction("Index", "Driver", new { area = "Driver" });
                        else if(user.Status == 3)
                            return RedirectToAction("Index", "Client", new { area = "Client" });
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
                    if (user.password == us.GenerateHashWithSalt(model.OldPassword,user.Salt))
                    {
                        string salt = us.GenerateSaltValue();
                        string password = us.GenerateHashWithSalt(model.ConfirmPassword, salt);
                        user.password = password;
                        user.Salt = salt;

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