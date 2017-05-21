using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KvieskTaxa.Database.Models
{
    public class Discount
    {
		#region Properties

		[Key]
        public int DiscountId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int DiscountSize { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidTo { get; set; }

        public ICollection<DiscountCode> DiscountCodes { get; set; }

		#endregion
	}
}