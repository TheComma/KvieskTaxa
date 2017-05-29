namespace KvieskTaxa.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DriverUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drivers", "LastLatitude", c => c.String());
            AddColumn("dbo.Drivers", "LastLongitude", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Drivers", "LastLongitude");
            DropColumn("dbo.Drivers", "LastLatitude");
        }
    }
}
