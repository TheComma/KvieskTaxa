/**
 * @(#) AdministratorController.cs
 */
using System.Web.Mvc;
using KvieskTaxa.Database;

namespace KvieskTaxa.Areas.Administrator.Controllers
{
	public class AdministratorController : Controller
	{
		//Services.IDiscountMailer DiscountMailer;
		
		private DataModelContext dbContext;

		public AdministratorController()
		{
			dbContext = new DataModelContext();
		}

		public ActionResult Index()
		{
			return View();
		}

		public void getReviews(  )
		{
			
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
