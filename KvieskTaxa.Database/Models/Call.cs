using System;
using System.ComponentModel.DataAnnotations;

namespace KvieskTaxa.Database.Models
{
	public class Call
    {
		#region Properties 

		[Key]
        public int CallId { get; set; }

        public string PickUpCordinates { get; set; }

        public string PickUpLocation { get; set; }

        public string DropByCordinates { get; set; }

        public string DropByLocation { get; set; }

		public float? Distance { get; set; }

        public int State { get; set; }

        public decimal? EstimatedPrice { get; set; }

        public DateTime SendTime { get; set; }

        public DateTime? AcceptTime { get; set; }

        public DateTime? FinishTime { get; set; }

        public DateTime BookTime { get; set; }

        [Range(1, 6)]
        public int Passangers { get; set; }

        public bool IsChildSeat { get; set; }

        public bool IsAnimals { get; set; }

        public bool IsSmoking { get; set; }

        public bool IsBaggage { get; set; }

		public int ClientId { get; set; }

		public virtual Client Client { get; set; }

		public int? DriverId { get; set; }

        public virtual Driver Driver { get; set; }

		#endregion
	}
}