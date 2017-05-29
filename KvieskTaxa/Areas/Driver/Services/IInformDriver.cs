using System.Net.Mail;

namespace KvieskTaxa.Areas.Driver.Services
{
    public interface IInformDriver
    {
        void inform(MailMessage cancelled);
    }
}