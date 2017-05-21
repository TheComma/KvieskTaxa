using System.ComponentModel.DataAnnotations;

namespace KvieskTaxa.Database.Models
{
    public class DiscountCode
    {
		#region Properties 

		[Key]
		public int DiscountCodeId { get; set; }

        public string Code { get; set; }

		public int ClientId { get; set; }

		public int DiscountId { get; set; }

		public virtual Discount Discount { get; set; }

        public virtual Client Client { get; set; }

		#endregion
	}
}