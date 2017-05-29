using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KvieskTaxa.Database.Models
{
    public class Discount: IValidatableObject
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

        public System.Collections.Generic.IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ValidFrom >= ValidTo)
            {
                yield return new ValidationResult("Galiojimo pabaiga turi būti po galiojimo pradžios");
            }
        }
    }
}