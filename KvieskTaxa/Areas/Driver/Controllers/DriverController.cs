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
            var driver = dbContext.Drivers.SingleOrDefault(d => d.DriverId == User.UserId);
            ViewBag.driverState = driver.State;
            //return View(model);
            return View(model);
        }


        [Authorize]
        public ActionResult showCalls()
        {
            var model = new CallDriver();
            model.Calls = dbContext.Calls.ToList();
            model.Drivers = dbContext.Drivers.ToList();
            var driver = dbContext.Drivers.SingleOrDefault(d => d.DriverId == User.UserId);
            ViewBag.driverState = driver.State;
            return View(model);
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
            //pasiimamas callas tas, kurio state==2/3, book time maziausias ir driverId == user.id
            if (stateId == 2)//Stovi ir vykdomas
            {
                var calls = dbContext.Calls.Where(c => c.State == 3 && c.DriverId == User.UserId);
                if (calls != null)
                {
                    var call = calls.OrderBy(x => x.BookTime).FirstOrDefault();
                    if (call != null)
                    {
                        call.State = 5; // Užbaigtas
                        driver.State = stateId;
                        dbContext.SaveChanges();
                    }
                    else if (driver.State == 5)
                    {
                        driver.State = stateId;
                        dbContext.SaveChanges();
                    }
                }
            }
            if (stateId == 3)
            {
                var calls = dbContext.Calls.Where(c => c.State == 2 && c.DriverId == User.UserId);
                if (calls != null)
                {
                    var call = calls.OrderBy(x => x.BookTime).FirstOrDefault();
                    if (call != null)
                    {
                        driver.State = stateId;
                        dbContext.SaveChanges();
                    }
                }
            }
            if (stateId == 4)//Veža ir priimtas
            {
                var calls = dbContext.Calls.Where(c => c.State == 2 && c.DriverId == User.UserId);
                if (calls != null)
                {
                    var call = calls.OrderBy(x => x.BookTime).FirstOrDefault();
                    if (call != null)
                    {
                        call.State = 3; // Vykdomas
                        driver.State = stateId;
                        dbContext.SaveChanges();
                    }
                }
            }
            if (stateId == 5)//Nedirba ir vykdomas
            {
                var calls = dbContext.Calls.Where(c => c.State == 3 && c.DriverId == User.UserId);
                if (calls != null)
                {
                    var call = calls.OrderBy(x => x.BookTime).FirstOrDefault();
                    if (call != null)
                    {
                        call.State = 5; // Užbaigtas
                    }
                }
                driver.State = stateId;
                dbContext.SaveChanges();
            }
            // truksta atsaukimo
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

                //var driver = dbContext.Drivers.SingleOrDefault(d => d.DriverId == User.UserId);
                if (call == null)
                {
                    return HttpNotFound();
                }
            if (call.State < 2)
            {
                //pranesti klientui, kad iskvietimas priimtas
                //driver.State = 2;
                call.State = 2;
                call.AcceptTime = DateTime.Now;
                call.DriverId = User.UserId;
                dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        public void receiveCall()
        {

        }

    }
}