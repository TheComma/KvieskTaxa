/**
 * @(#) DiscountMailer.cs
 */
using KvieskTaxa.Database.Models;
using KvieskTaxa.Database;
using System.Data.Entity;

namespace KvieskTaxa.Areas.Administrator.Services
{
	public class DiscountMailer : IDiscountMailer
	{
		private IMailService MailService;
		private DataModelContext dbContext;
		
		public DiscountMailer(IMailService MS, DataModelContext dbContext)
		{
            MailService = MS;
            this.dbContext = dbContext;
		}

        public void sendDiscountCodes(int id)
        {
            DiscountCode code = dbContext.DiscountCodes.FirstOrDefault(x => x.Code == id);
        }
    }
}
