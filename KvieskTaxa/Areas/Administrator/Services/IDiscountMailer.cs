/**
 * @(#) IDiscountMailer.cs
 */

namespace KvieskTaxa.Areas.Administrator.Services
{
	public interface IDiscountMailer
	{
        void sendDiscountCodes(int id);
	}
}
