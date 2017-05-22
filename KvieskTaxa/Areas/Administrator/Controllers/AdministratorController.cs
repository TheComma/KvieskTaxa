/**
 * @(#) AdministratorController.cs
 */
using System.Web.Mvc;
using KvieskTaxa.Database;
using KvieskTaxa.Database.Models;
using System.Linq;

namespace KvieskTaxa.Areas.Administrator.Controllers
{
	public class AdministratorController : Controller
	{
		Services.IDiscountMailer DiscountMailer;
		private DataModelContext dbContext;

		public AdministratorController()
		{
			dbContext = new DataModelContext();
            DiscountMailer = new Services.DiscountMailer(new Services.MailService(), dbContext);
        }

		public ActionResult Index()
		{
			return View();
		}

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

        public ActionResult GetTariffs()
        {
            return View(dbContext.Tariffs.ToList());
        }

        public ActionResult CreateTariff()
        {
            ViewBag.DriverId = new SelectList(dbContext.Drivers.ToList(), "DriverId", "Name");
            return View();
        }

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

        public void editTariff(  )
		{
			
		}
		
		public void saveTariff(  )
		{
			
		}
		
		public void validateTariff(  )
		{
			
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
