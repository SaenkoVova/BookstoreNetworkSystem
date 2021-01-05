namespace BookstoreNetworkSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBookProps : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookStores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BookStoreBooks",
                c => new
                    {
                        BookStore_Id = c.Int(nullable: false),
                        Book_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BookStore_Id, t.Book_Id })
                .ForeignKey("dbo.BookStores", t => t.BookStore_Id, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true)
                .Index(t => t.BookStore_Id)
                .Index(t => t.Book_Id);
            
            AddColumn("dbo.Books", "Price", c => c.Double(nullable: false));
            AddColumn("dbo.Books", "Date", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookStoreBooks", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.BookStoreBooks", "BookStore_Id", "dbo.BookStores");
            DropIndex("dbo.BookStoreBooks", new[] { "Book_Id" });
            DropIndex("dbo.BookStoreBooks", new[] { "BookStore_Id" });
            DropColumn("dbo.Books", "Date");
            DropColumn("dbo.Books", "Price");
            DropTable("dbo.BookStoreBooks");
            DropTable("dbo.BookStores");
        }
    }
}
