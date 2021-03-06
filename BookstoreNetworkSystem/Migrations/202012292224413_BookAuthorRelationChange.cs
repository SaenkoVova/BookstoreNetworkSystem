﻿namespace BookstoreNetworkSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookAuthorRelationChange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Authors", "Book_Id", "dbo.Books");
            DropIndex("dbo.Authors", new[] { "Book_Id" });
            CreateIndex("dbo.Books", "AuthorId");
            AddForeignKey("dbo.Books", "AuthorId", "dbo.Authors", "Id", cascadeDelete: true);
            DropColumn("dbo.Authors", "Book_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Authors", "Book_Id", c => c.Int());
            DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Books", new[] { "AuthorId" });
            CreateIndex("dbo.Authors", "Book_Id");
            AddForeignKey("dbo.Authors", "Book_Id", "dbo.Books", "Id");
        }
    }
}
