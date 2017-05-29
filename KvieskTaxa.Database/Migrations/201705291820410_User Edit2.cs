namespace KvieskTaxa.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserEdit2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "password", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "password", c => c.String(maxLength: 20));
        }
    }
}
