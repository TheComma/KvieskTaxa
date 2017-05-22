/**
 * @(#) AdministratorController.cs
 */
using System.Web.Mvc;
using KvieskTaxa.Database;
using KvieskTaxa.Database.Models;
using KvieskTaxa.Controllers.Base;
using System.Data.Entity;
using System.Linq;
using System.Net;

namespace KvieskTaxa.Areas.Administrator.Controllers
{
	public class AdministratorController : BaseController
    {
		Services.IDiscountMailer DiscountMailer;
		private DataModelContext dbContext;

		public AdministratorController()
		{
			dbContext = new DataModelContext();
            DiscountMailer = new Services.DiscountMailer(new Services.MailService(), dbContext);
        }

        [Authorize]
		public ActionResult Index()
		{
			return View();
		}

        [Authorize]
        public ActionResult getReviews()
		{
            return View(dbContext.Reviews.ToList());
		}
		
		public void showDiscountForm(  )
		{
			
		}
		
		public void saveDiscount(  )
		{
			
		}
		
		public void validateDiscount(  )
		{
			
		}
		
		public void generateDiscountCode(  )
		{
			
		}

        [Authorize]
        public ActionResult GetTariffs()
        {
            return View(dbContext.Tariffs.ToList());
        }

        [Authorize]
        public ActionResult CreateTariff()
        {
            ViewBag.DriverId = new SelectList(dbContext.Drivers.ToList(), "DriverId", "Name");
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult CreateTariff(Tariff tariff)
        {
            if (ModelState.IsValid)
            {
                dbContext.Tariffs.Add(tariff);
                dbContext.SaveChanges();
                return RedirectToAction("GetTariffs", "Administrator");
            }
            ViewBag.DriverId = new SelectList(dbContext.Drivers.ToList(), "DriverId", "Name");
            return View(tariff);
        }

        [Authorize]
        public ActionResult editTariff(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tariff tariff = dbContext.Tariffs.Find(id);
            if (tariff == null)
            {
                return HttpNotFound();
            }
            ViewBag.DriverId = new SelectList(dbContext.Drivers.ToList(), "DriverId", "Name");
            return View(tariff);
        }

        [Authorize]
        [HttpPost]
        public ActionResult editTariff(Tariff tariff)
        {
            if (ModelState.IsValid)
            {
                dbContext.Entry(tariff).State = EntityState.Modified;
                dbContext.SaveChanges();
                return RedirectToAction("GetTariffs", "Administrator");
            }
            ViewBag.DriverId = new SelectList(dbContext.Drivers.ToList(), "DriverId", "Name");
            return View();
        }

        [Authorize]
        public ActionResult DeleteTariff(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tariff tariff = dbContext.Tariffs.Find(id);
            if (tariff == null)
            {
                return HttpNotFound();
            }
            dbContext.Tariffs.Remove(tariff);
            dbContext.SaveChanges();

            return RedirectToAction("GetTariffs");
        }

        public void editTransportationSettings(  )
		{
			
		}
		
		public void saveTransportationSettings(  )
		{
			
		}
		
		public void editDriver(  )
		{
			
		}
		
		public void saveDriver(  )
		{
			
		}
		
		public void validateDriver(  )
		{
			
		}
		
	}
	
}
