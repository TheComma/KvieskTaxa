/**
 * @(#) MailService.cs
 */
using System.Net.Mail;

namespace KvieskTaxa.Areas.Administrator.Services
{
	public class MailService : IMailService
	{
		SmtpClient SmtpClient;

        public MailService()
        {
            SmtpClient = new SmtpClient();
        }

        public void sendMail(MailMessage message)
		{
            SmtpClient.Send(message);
		}
	}
}
