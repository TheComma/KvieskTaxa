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
        public void changeDriverState(int id)
        {

            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Driver driver = dbContext.Drivers.Find(id);
        }
        [HttpPost, ActionName("Edit")]
        [Authorize]
        public ActionResult acceptCall(int id)
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

            call.State = 2;
            call.AcceptTime = DateTime.Now;
            //call.DriverId = dbContext.Use
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public void receiveCall()
        {

        }

    }
}