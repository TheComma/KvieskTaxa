namespace KvieskTaxa.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CallEdit2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Calls", "PickUpLongitude", c => c.String());
            AddColumn("dbo.Calls", "PickUpLatitude", c => c.String());
            AddColumn("dbo.Calls", "DropByLongitude", c => c.String());
            AddColumn("dbo.Calls", "DropByLatitude", c => c.String());
            DropColumn("dbo.Calls", "PickUpLocation");
            DropColumn("dbo.Calls", "DropByCordinates");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Calls", "DropByCordinates", c => c.String());
            AddColumn("dbo.Calls", "PickUpLocation", c => c.String());
            DropColumn("dbo.Calls", "DropByLatitude");
            DropColumn("dbo.Calls", "DropByLongitude");
            DropColumn("dbo.Calls", "PickUpLatitude");
            DropColumn("dbo.Calls", "PickUpLongitude");
        }
    }
}
