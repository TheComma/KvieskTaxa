using System.ComponentModel.DataAnnotations;

namespace KvieskTaxa.Database.Models
{
	public class Review
	{
		#region Properties

		[Key]
		public int ReviewId { get; set; }

		public string Description { get; set; }

		public int Rating { get; set; }

		public int DriverId { get; set; }

		public int ClientId { get; set; }

		public virtual Driver Driver { get; set; }

		public virtual Client Client { get; set; }

		#endregion
	}
}
