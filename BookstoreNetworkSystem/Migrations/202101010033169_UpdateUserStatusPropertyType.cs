namespace BookstoreNetworkSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserStatusPropertyType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "status", c => c.Boolean(nullable: false, defaultValue: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "status", c => c.String());
        }
    }
}
