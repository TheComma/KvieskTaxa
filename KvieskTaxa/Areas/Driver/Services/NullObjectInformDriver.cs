using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace KvieskTaxa.Areas.Driver.Services
{
    public class NullObjectInformDriver : IInformDriver
    {
        public void inform(MailMessage updated) { } 
    }
}