using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace KvieskTaxa.Areas.Driver.Services
{
    public class InformDriver : IInformDriver
    {
        SmtpClient SmtpClient;
        public void inform(MailMessage cancelled)
        {
            SmtpClient.Send(cancelled);
        }
    }
}