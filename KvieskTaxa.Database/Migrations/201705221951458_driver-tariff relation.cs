namespace KvieskTaxa.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class drivertariffrelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tariffs", "TariffId", "dbo.Drivers");
            DropIndex("dbo.Tariffs", new[] { "TariffId" });
            DropColumn("dbo.Tariffs", "DriverId");
            RenameColumn(table: "dbo.Tariffs", name: "TariffId", newName: "DriverId");
            DropPrimaryKey("dbo.Tariffs");
            AddColumn("dbo.Tariffs", "TariffId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Tariffs", "DriverId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Tariffs", "TariffId");
            CreateIndex("dbo.Tariffs", "DriverId");
            AddForeignKey("dbo.Tariffs", "DriverId", "dbo.Drivers", "DriverId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tariffs", "DriverId", "dbo.Drivers");
            DropIndex("dbo.Tariffs", new[] { "DriverId" });
            DropPrimaryKey("dbo.Tariffs");
            AlterColumn("dbo.Tariffs", "DriverId", c => c.Int());
            AlterColumn("dbo.Tariffs", "TariffId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Tariffs", "TariffId");
            RenameColumn(table: "dbo.Tariffs", name: "DriverId", newName: "TariffId");
            AddColumn("dbo.Tariffs", "DriverId", c => c.Int());
            CreateIndex("dbo.Tariffs", "TariffId");
            AddForeignKey("dbo.Tariffs", "TariffId", "dbo.Drivers", "DriverId");
        }
    }
}
