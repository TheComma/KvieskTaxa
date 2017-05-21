namespace KvieskTaxa.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administrators",
                c => new
                    {
                        AdministratorId = c.Int(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.AdministratorId)
                .ForeignKey("dbo.Users", t => t.AdministratorId)
                .Index(t => t.AdministratorId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        username = c.String(maxLength: 20),
                        password = c.String(maxLength: 20),
                        CreateDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.Int(nullable: false),
                        Email = c.String(),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.ClientId)
                .ForeignKey("dbo.Users", t => t.ClientId)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.Calls",
                c => new
                    {
                        CallId = c.Int(nullable: false, identity: true),
                        PickUp = c.String(),
                        DropBy = c.String(),
                        Distance = c.Single(nullable: false),
                        State = c.Int(nullable: false),
                        EstimatedPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SendTime = c.DateTime(nullable: false),
                        AcceptTime = c.DateTime(nullable: false),
                        FinishTime = c.DateTime(nullable: false),
                        BookTime = c.DateTime(nullable: false),
                        Passangers = c.Int(nullable: false),
                        IsChildSeat = c.Boolean(nullable: false),
                        IsAnimals = c.Boolean(nullable: false),
                        IsSmoking = c.Boolean(nullable: false),
                        IsBaggage = c.Boolean(nullable: false),
                        ClientId = c.Int(nullable: false),
                        DriverId = c.Int(),
                    })
                .PrimaryKey(t => t.CallId)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Drivers", t => t.DriverId)
                .Index(t => t.ClientId)
                .Index(t => t.DriverId);
            
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        DriverId = c.Int(nullable: false),
                        State = c.Int(nullable: false),
                        Name = c.String(),
                        Seats = c.Int(nullable: false),
                        IsChildSeat = c.Boolean(nullable: false),
                        IsAnimals = c.Boolean(nullable: false),
                        IsSmoking = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DriverId)
                .ForeignKey("dbo.Users", t => t.DriverId)
                .Index(t => t.DriverId);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ReviewId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Rating = c.Int(nullable: false),
                        DriverId = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReviewId)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Drivers", t => t.DriverId, cascadeDelete: true)
                .Index(t => t.DriverId)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.Tariffs",
                c => new
                    {
                        TariffId = c.Int(nullable: false),
                        EntryPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        KilometersPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DriverId = c.Int(),
                        ValidFrom = c.DateTime(nullable: false),
                        ValidTo = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TariffId)
                .ForeignKey("dbo.Drivers", t => t.TariffId)
                .Index(t => t.TariffId);
            
            CreateTable(
                "dbo.DiscountCodes",
                c => new
                    {
                        DiscountCodeId = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        ClientId = c.Int(nullable: false),
                        DiscountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DiscountCodeId)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Discounts", t => t.DiscountId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.DiscountId);
            
            CreateTable(
                "dbo.Discounts",
                c => new
                    {
                        DiscountId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        DiscountSize = c.Int(nullable: false),
                        ValidFrom = c.DateTime(nullable: false),
                        ValidTo = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DiscountId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Administrators", "AdministratorId", "dbo.Users");
            DropForeignKey("dbo.Clients", "ClientId", "dbo.Users");
            DropForeignKey("dbo.DiscountCodes", "DiscountId", "dbo.Discounts");
            DropForeignKey("dbo.DiscountCodes", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Drivers", "DriverId", "dbo.Users");
            DropForeignKey("dbo.Tariffs", "TariffId", "dbo.Drivers");
            DropForeignKey("dbo.Reviews", "DriverId", "dbo.Drivers");
            DropForeignKey("dbo.Reviews", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Calls", "DriverId", "dbo.Drivers");
            DropForeignKey("dbo.Calls", "ClientId", "dbo.Clients");
            DropIndex("dbo.DiscountCodes", new[] { "DiscountId" });
            DropIndex("dbo.DiscountCodes", new[] { "ClientId" });
            DropIndex("dbo.Tariffs", new[] { "TariffId" });
            DropIndex("dbo.Reviews", new[] { "ClientId" });
            DropIndex("dbo.Reviews", new[] { "DriverId" });
            DropIndex("dbo.Drivers", new[] { "DriverId" });
            DropIndex("dbo.Calls", new[] { "DriverId" });
            DropIndex("dbo.Calls", new[] { "ClientId" });
            DropIndex("dbo.Clients", new[] { "ClientId" });
            DropIndex("dbo.Administrators", new[] { "AdministratorId" });
            DropTable("dbo.Discounts");
            DropTable("dbo.DiscountCodes");
            DropTable("dbo.Tariffs");
            DropTable("dbo.Reviews");
            DropTable("dbo.Drivers");
            DropTable("dbo.Calls");
            DropTable("dbo.Clients");
            DropTable("dbo.Users");
            DropTable("dbo.Administrators");
        }
    }
}
