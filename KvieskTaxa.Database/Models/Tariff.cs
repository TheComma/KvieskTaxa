using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KvieskTaxa.Database.Models
{
    public class Tariff: IValidatableObject
    {
		#region Properties

		[Key]
        public int TariffId { get; set; }

        public decimal EntryPrice { get; set; }

        public decimal KilometersPrice { get; set; }
		
		public int DriverId { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidTo { get; set; }

        public virtual Driver Driver { get; set; }

        #endregion

        public System.Collections.Generic.IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ValidFrom >= ValidTo)
            {
                yield return new ValidationResult("Galiojimo pabaiga turi būti po galiojimo pradžios");
            }

            if (EntryPrice <= 0 || KilometersPrice <= 0)
            {
                yield return new ValidationResult("Tarifas negali būti nulinis");
            }
        }
    }
}