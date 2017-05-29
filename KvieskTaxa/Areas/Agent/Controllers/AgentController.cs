using KvieskTaxa.Database;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Device.Location;

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

        public void FindClosestDriver(Database.Models.Call call)
        {
            if (IsDriverAvailable())
            {
                double clientlatitude = Double.Parse(call.PickUpLatitude);
                double clientlongitude = Double.Parse(call.PickUpLongitude);

                double minDist = 0;

                Database.Models.Driver driver = new Database.Models.Driver();

                var cCordinates = new GeoCoordinate(clientlatitude, clientlongitude);

                foreach (var item in db.Drivers.Where(x => x.State == 2))
                {
                    var dCordicates = new GeoCoordinate(Double.Parse(item.LastLatitude), Double.Parse(item.LastLongitude));
                    double dist = cCordinates.GetDistanceTo(dCordicates);
                    if (dist < minDist || minDist == 0)
                    {
                        minDist = dist;
                        driver = item;
                    }
                }

                call.DriverId = driver.DriverId;
                call.Driver = driver;
            }

        }

        public bool IsDriverAvailable()
        {
            if (db.Drivers.Where(x => x.State == 0).Count() > 0)
                return true;
            else
                return false;
        }
    }
}