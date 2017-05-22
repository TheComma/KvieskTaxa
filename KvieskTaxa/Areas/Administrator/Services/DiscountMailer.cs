/**
 * @(#) DiscountMailer.cs
 */
using KvieskTaxa.Database.Models;
using KvieskTaxa.Database;
using System.Net.Mail;
using System.Linq;

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
			Discount discount = dbContext.Discounts.FirstOrDefault(x => x.DiscountId == id);
			foreach (DiscountCode code in discount.DiscountCodes)
			{
				KvieskTaxa.Database.Models.Client client = code.Client;
				string message = generateEmailBody(discount.Description, code.Code);
				MailMessage mail = new MailMessage("info@kviesktaxa.lt", client.Email, discount.Title, discount.Description);

				MailService.sendMail(mail);
			}
		}

		private string generateEmailBody(string description, string code)
		{
			string message = "Sveiki!";
			message += "\n" + description;
			message += "\nNuolaidos kodas: " + code;
			message += "\n KvieskTaxa.lt";

			return message;
		}
	}
}
