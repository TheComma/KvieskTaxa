using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KvieskTaxa.Database.Models
{
    public class Driver
    {
		#region Properties

		[Key, ForeignKey("User")]
		public int DriverId { get; set; }

		public int State { get; set; }

        public string Name { get; set; }

        public int Seats { get; set; }

        public bool IsChildSeat { get; set; }

        public bool IsAnimals { get; set; }

        public bool IsSmoking { get; set; }

		public virtual User User { get; set; }

		public virtual Tariff Tariff { get; set; }

		public virtual ICollection<Call> Calls { get; set; }

		public virtual ICollection<Review> Reviews { get; set; }

		#endregion
	}
}