using KvieskTaxa.Controllers.Base;
using KvieskTaxa.Database;
using KvieskTaxa.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KvieskTaxa.Areas.Client.Controllers
{
    public class ClientController : BaseController
    {
        private DataModelContext dbContext;

        public ClientController()
        {
            dbContext = new DataModelContext();
        }
        // GET: Client/Client
        [Authorize]
        public ActionResult IssueCall()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult IssueCall(Call call)
        {
            if (ModelState.IsValid)
            {
                call.SendTime = DateTime.Now;
                call.BookTime = DateTime.Now;
                call.State = 1;
                call.ClientId = User.UserId;
                dbContext.Calls.Add(call);
                dbContext.SaveChanges();
                return View();
            }
            return View();
        }

        public ActionResult DriveProgress()
        {
            return View();
        }

        public ActionResult Index()
        {
           return View();
        }
    }
}