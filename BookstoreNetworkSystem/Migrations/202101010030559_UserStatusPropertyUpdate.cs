﻿namespace BookstoreNetworkSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserStatusPropertyUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "status");
        }
    }
}
