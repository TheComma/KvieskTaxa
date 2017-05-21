/**
 * @(#) NullObjectMailService.cs
 */
using System.Net.Mail;

namespace KvieskTaxa.Areas.Administrator.Services
{
	public class NullObjectMailService : IMailService
	{
		public void sendMail(MailMessage message)
		{
			
		}
	}
}
