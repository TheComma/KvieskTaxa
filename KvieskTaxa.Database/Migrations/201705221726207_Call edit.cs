namespace KvieskTaxa.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Calledit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Calls", "PickUpCordinates", c => c.String());
            AddColumn("dbo.Calls", "PickUpLocation", c => c.String());
            AddColumn("dbo.Calls", "DropByCordinates", c => c.String());
            AddColumn("dbo.Calls", "DropByLocation", c => c.String());
            DropColumn("dbo.Calls", "PickUp");
            DropColumn("dbo.Calls", "DropBy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Calls", "DropBy", c => c.String());
            AddColumn("dbo.Calls", "PickUp", c => c.String());
            DropColumn("dbo.Calls", "DropByLocation");
            DropColumn("dbo.Calls", "DropByCordinates");
            DropColumn("dbo.Calls", "PickUpLocation");
            DropColumn("dbo.Calls", "PickUpCordinates");
        }
    }
}
