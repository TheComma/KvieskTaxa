using System.Web.Mvc;
using KvieskTaxa.Database;
using KvieskTaxa.Database.Models;
using KvieskTaxa.Controllers.Base;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using System;

namespace KvieskTaxa.Areas.Driver.Controllers
{
    public class DriverController : BaseController
    {
        private DataModelContext dbContext;

        public DriverController()
        {
            dbContext = new DataModelContext();
        }

        [Authorize]
        public ActionResult Index()
        {
            var model = new CallDriver();
            model.Calls = dbContext.Calls.ToList();
            model.Drivers = dbContext.Drivers.ToList();
            //return View(model);
            return View(model);
        }
        [Authorize]
        public ActionResult showCalls()
        {
            return View(dbContext.Calls.ToList());
        }
        [Authorize]
        public ActionResult openCallInfo(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var call = dbContext.Calls.SingleOrDefault(d => d.CallId == id);
            return View(call);
        }
        [Authorize]
        public ActionResult changeDriverState(int stateId)
        {
            var driver = dbContext.Drivers.SingleOrDefault(d => d.DriverId == User.UserId);
            driver.State = stateId;
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        //[HttpPost, ActionName("Edit")]
        [Authorize]
        public ActionResult acceptCall(int id)
        {
            var model = new CallDriver();
            model.Calls = dbContext.Calls.ToList();
            model.Drivers = dbContext.Drivers.ToList();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Call call = dbContext.Calls.Find(id);

            var driver = dbContext.Drivers.SingleOrDefault(d => d.DriverId == User.UserId);
            if (call == null)
            {
                return HttpNotFound();
            }
            driver.State = 2;
            call.State = 2;
            call.AcceptTime = DateTime.Now;
            call.DriverId = User.UserId;
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public void receiveCall()
        {

        }

    }
}