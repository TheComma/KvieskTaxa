namespace KvieskTaxa.Database.Migrations
{
    using System.Data.Entity.Migrations;
    using KvieskTaxa.Database.Models;
    using System;

    internal sealed class Configuration : DbMigrationsConfiguration<DataModelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataModelContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );

            AddUser(context);
            AddReviews(context);
        }

        private void AddUser(DataModelContext context)
        {
            User admin = new User() { UserId = 1, username = "admin", password = "admin", Status = 1, CreateDate = DateTime.Now };
            User driver = new User() { UserId = 2, username = "driver", password = "driver", Status = 2, CreateDate = DateTime.Now };
            User client = new User() { UserId = 3, username = "client", password = "client", Status = 3, CreateDate = DateTime.Now };
            Administrator admindata = new Administrator() { AdministratorId = 1, Email = "admin@admin.lt" };
            Driver driverdata = new Driver() { DriverId = 2, IsAnimals = true, IsChildSeat = true, IsSmoking = true, Name = "test", Seats = 5, State = 1 };
            Client clientdata = new Client() { ClientId = 3, Email = "client@client.lt" };
            admin.Administrator = admindata;
            driver.Driver = driverdata;
            client.Client = clientdata;

            context.Users.AddOrUpdate(admin, driver, client);
            context.SaveChanges();
        }

        private void AddReviews(DataModelContext context)
        {
            Review review1 = new Review() { ClientId = 3, DriverId = 2, Rating = 5, Description = "Labai gera taxi programele. Intuityvu ir inovatyvu." };
            Review review2 = new Review() { ClientId = 3, DriverId = 2, Rating = 2, Description = "Kelione kainavo brangiau nei prognozavo." };
            Review review3 = new Review() { ClientId = 3, DriverId = 2, Rating = 1, Description = "Tai kad cia niekas neveikia.." };

            context.Reviews.Add(review1);
            context.Reviews.Add(review2);
            context.Reviews.Add(review3);

            context.SaveChanges();
        }
    }
}
