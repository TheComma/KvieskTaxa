/**
 * @(#) AdministratorController.cs
 */
using System.Web.Mvc;
using KvieskTaxa.Database;
using KvieskTaxa.Database.Models;
using KvieskTaxa.Controllers.Base;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using System.Net;
using KvieskTaxa.Services;

namespace KvieskTaxa.Areas.Administrator.Controllers
{
	public class AdministratorController : BaseController
	{
		Services.IDiscountMailer DiscountMailer;
		private DataModelContext dbContext;
		private static System.Random random = new System.Random();
        private UserSecurity us;

        public AdministratorController()
		{
			dbContext = new DataModelContext();
			DiscountMailer = new Services.DiscountMailer(new Services.MailService(), dbContext);
            us = new UserSecurity(dbContext);
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

		[Authorize]
		public ActionResult GetDiscounts()
		{
			return View(dbContext.Discounts.ToList());
		}

		[Authorize]
		public ActionResult CreateDiscount()
		{
			return View();
		}

		[Authorize]
		[HttpPost]
		public ActionResult CreateDiscount(Discount discount)
		{
			if (ModelState.IsValid)
			{
				dbContext.Discounts.Add(discount);
				dbContext.SaveChanges();
				return RedirectToAction("GetDiscounts", "Administrator");
			}

			return View(discount);
		}
	   
		[Authorize]
		public ActionResult EditDiscount(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Discount discount = dbContext.Discounts.Find(id);
			if (discount == null)
			{
				return HttpNotFound();
			}

			return View(discount);
		}

		[Authorize]
		[HttpPost]
		public ActionResult EditDiscount(Discount discount)
		{
			if (ModelState.IsValid)
			{
				dbContext.Entry(discount).State = EntityState.Modified;
				dbContext.SaveChanges();
				return RedirectToAction("GetDiscounts", "Administrator");
			}

			return View(discount);
		}

		[Authorize]
		public ActionResult DeleteDiscount(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Discount discount = dbContext.Discounts.Find(id);
			if (discount == null)
			{
				return HttpNotFound();
			}
			dbContext.Discounts.Remove(discount);
			dbContext.SaveChanges();

			return RedirectToAction("GetDiscounts", "Administrator");
		}

		[Authorize]
		public ActionResult GenerateDiscountCodes(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Discount discount = dbContext.Discounts.Find(id);
			if (discount == null)
			{
				return HttpNotFound();
			}

			List<Database.Models.Client> clients = dbContext.Clients.ToList();

			foreach(Database.Models.Client client in clients)
			{
				string code = generateDiscountCode();
				DiscountCode discountCode = new DiscountCode() { ClientId=client.ClientId, DiscountId=discount.DiscountId, Code=code };
				dbContext.DiscountCodes.Add(discountCode);
			}

			dbContext.SaveChanges();

			return RedirectToAction("GetDiscounts", "Administrator");
		}

		public ActionResult SendDiscount(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			DiscountMailer.sendDiscountCodes((int) id);

			return RedirectToAction("GetDiscounts", "Administrator");
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
			return View(tariff);
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

			return RedirectToAction("GetTariffs", "Administrator");
		}

		[Authorize]
		public ActionResult editTransportationSettings(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Database.Models.Driver driver = dbContext.Drivers.Find(id);
			if (driver == null)
			{
				return HttpNotFound();
			}

			return View(driver);
		}

		[Authorize]
		[HttpPost]
		public ActionResult editTransportationSettings(Database.Models.Driver driver)
		{
			if (ModelState.IsValid)
			{
				dbContext.Entry(driver).State = EntityState.Modified;
				dbContext.SaveChanges();
				return RedirectToAction("GetDrivers", "Administrator");
			}

			return View(driver);
		}

		[Authorize]
		public ActionResult GetDrivers()
		{
			return View(dbContext.Drivers.ToList());
		}

		[Authorize]
		public ActionResult CreateDriver()
		{
			return View();
		}

		[Authorize]
		[HttpPost]
		public ActionResult CreateDriver(Database.Models.Driver driver)
		{
			if (ModelState.IsValid)
			{
				driver.User.CreateDate = System.DateTime.Now;
				driver.User.Status = 2;
                driver.State = 1;
                string salt = us.GenerateSaltValue();
                string password = us.GenerateHashWithSalt(driver.User.password, salt);
                driver.User.password = password;
                driver.User.Salt = salt;
                dbContext.Drivers.Add(driver);
				dbContext.SaveChanges();
				return RedirectToAction("GetDrivers", "Administrator");
			}

			return View(driver);
		}

		[Authorize]
		public ActionResult editDriver(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Database.Models.Driver driver = dbContext.Drivers.Find(id);
			if (driver == null)
			{
				return HttpNotFound();
			}
			driver.User.password = "";

			return View(driver);
		}

		[Authorize]
		[HttpPost]
		public ActionResult editDriver(Database.Models.Driver driver)
		{
			if (ModelState.IsValid)
			{
				dbContext.Entry(driver).State = EntityState.Modified;
				dbContext.SaveChanges();
				return RedirectToAction("GetDrivers", "Administrator");
			}

			return View(driver);
		}

		[Authorize]
		public ActionResult DeleteDriver(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Database.Models.Driver driver = dbContext.Drivers.Find(id);
			if (driver == null)
			{
				return HttpNotFound();
			}
			dbContext.Drivers.Remove(driver);
			dbContext.SaveChanges();

			return RedirectToAction("GetDrivers", "Administrator");
		}

		private string generateDiscountCode()
		{
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			return new string(Enumerable.Repeat(chars, 10)
			  .Select(s => s[random.Next(s.Length)]).ToArray());
		}
	}
	
}
