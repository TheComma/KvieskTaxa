/**
 * @(#) AdministratorController.cs
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KvieskTaxa.Database.Models;
using KvieskTaxa.Database;

namespace KvieskTaxa.Areas.Administrator.Controllers
{
	public class AdministratorController : Controller
    {
		Services.IDiscountMailer DiscountMailer;
		
		DataModelContext dbContext;

        public AdministratorController()
        {
            dbContext = new DataModelContext();
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
