using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KvieskTaxa.Database.Models
{
	public class Administrator
    {
		#region Properties 

		[Key, ForeignKey("User")]
		public int AdministratorId { get; set; }

        public string Email { get; set; }

		public virtual User User { get; set; }

		#endregion

	}
}