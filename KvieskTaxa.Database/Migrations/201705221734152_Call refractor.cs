namespace KvieskTaxa.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Callrefractor : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Calls", "Distance", c => c.Single());
            AlterColumn("dbo.Calls", "EstimatedPrice", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Calls", "AcceptTime", c => c.DateTime());
            AlterColumn("dbo.Calls", "FinishTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Calls", "FinishTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Calls", "AcceptTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Calls", "EstimatedPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Calls", "Distance", c => c.Single(nullable: false));
        }
    }
}
