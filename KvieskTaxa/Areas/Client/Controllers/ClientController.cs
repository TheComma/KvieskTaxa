using KvieskTaxa.Areas.Agent.Controllers;
using KvieskTaxa.Areas.Driver.Controllers;
using KvieskTaxa.Controllers.Base;
using KvieskTaxa.Database;
using KvieskTaxa.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            Call call = dbContext.Calls.Where(c => c.ClientId == User.UserId && c.State == 1).FirstOrDefault();
            if (call == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("ActiveCall", call);
            }
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
                call.PickUpLatitude = Request.Form["posLat"];
                call.PickUpLongitude = Request.Form["posLng"];
                call.DropByLatitude = Request.Form["destLat"];
                call.DropByLongitude = Request.Form["destLng"];
                Call newCall = dbContext.Calls.Add(call);
                dbContext.SaveChanges();
                new AgentController().FindClosestDriver(newCall);
                return RedirectToAction("ActiveCall", new { @id = newCall.CallId });
            }
            return View();
        }

        [Authorize]
        public ActionResult ActiveCall(int id)
        {
            Call call = dbContext.Calls.Find(id);
            return View(call);
        }

        [Authorize]
        public ActionResult CancelCall(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Call call = dbContext.Calls.Find(id);
            if (call == null)
            {
                return HttpNotFound();
            }
            if (call.DriverId != null)
            {
                new DriverController().UpdateStatus(call.DriverId);
            }
            dbContext.Calls.Remove(call);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Index()
        {
           Call call = dbContext.Calls.Where(c => c.ClientId == User.UserId).FirstOrDefault();
           if (call == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("ActiveCall", new { @id = call.CallId });
            }
        }
    }
}