using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KvieskTaxa.Database.Models
{
    public class Tariff
    {
		#region Properties

		[Key,ForeignKey("Driver")]
        public int TariffId { get; set; }

        public decimal EntryPrice { get; set; }

        public decimal KilometersPrice { get; set; }
		
		public int? DriverId { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidTo { get; set; }

        public virtual Driver Driver { get; set; }

		#endregion
	}
}