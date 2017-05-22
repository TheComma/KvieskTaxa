using System.Data.Entity;
using KvieskTaxa.Database.Models;

namespace KvieskTaxa.Database
{
	public class DataModelContext : DbContext
	{
		public DataModelContext() : base("name=DefaultConnection")
		{ }

		#region Properties

		public virtual DbSet<Administrator> Administrators { get; set; }

		public virtual DbSet<Call> Calls { get; set; }

		public virtual DbSet<Client> Clients { get; set; }

		public virtual DbSet<Discount> Discounts { get; set; }

		public virtual DbSet<DiscountCode> DiscountCodes { get; set; }

		public virtual DbSet<Driver> Drivers { get; set; }

		public virtual DbSet<Tariff> Tariffs { get; set; }

		public virtual DbSet<User> Users { get; set; }

		public virtual DbSet<Review> Reviews { get; set; }

		#endregion
	}
}
