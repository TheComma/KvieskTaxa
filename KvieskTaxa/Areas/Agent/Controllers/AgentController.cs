using KvieskTaxa.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KvieskTaxa.Areas.Agent.Controllers
{
    public class AgentController : Controller
    {
        private DataModelContext db;

        public AgentController()
        {
            db = new DataModelContext();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult UpdateDriversLocation(int id, string latitude, string longitude)
        {
            var Driver = db.Drivers.FirstOrDefault(x => x.DriverId == id);
            if (Driver != null)
            {
                Driver.LastLatitude = latitude;
                Driver.LastLongitude = longitude;

                db.Entry(Driver).State = EntityState.Modified;

                db.SaveChanges();
                return Json(new { code = "200", msg = "Success" });
            }
            return Json(new { code = "400", msg = "Driver not found" });
        }
    }
}