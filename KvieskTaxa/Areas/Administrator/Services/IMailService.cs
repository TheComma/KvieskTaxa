/**
 * @(#) IMailService.cs
 */
using System.Net.Mail;

namespace KvieskTaxa.Areas.Administrator.Services
{
	public interface IMailService
	{
		void sendMail(MailMessage message);
	}
}
