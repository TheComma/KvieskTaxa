using System;
using System.ComponentModel.DataAnnotations;

namespace KvieskTaxa.Database.Models
{
    public class User
    {
		#region Properties

		[Key]
        public int UserId { get; set; }

		[StringLength(20)]
        public string username { get; set; }

		[StringLength(20)]
		public string password { get; set; }

        public DateTime CreateDate { get; set; }

		public int Status { get; set; }

		public virtual Administrator Administrator { get; set; }

		public virtual Driver Driver { get; set; }

		public virtual Client Client { get; set; }

		#endregion
	}
}