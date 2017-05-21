using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KvieskTaxa.Database.Models
{
    public class Client 
    {
		#region Properties

		[Key, ForeignKey("User")]
		public int ClientId { get; set; }

        public string Email { get; set; }

		public int? UserId { get; set; }

        public virtual ICollection<DiscountCode> DiscountCodes { get; set; }

        public virtual ICollection<Call> Calls { get; set; }

		public virtual ICollection<Review> Reviews { get; set; }

		public virtual User User { get; set; }

		#endregion
	}
}