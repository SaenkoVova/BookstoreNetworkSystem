using BookstoreNetworkSystem.models;
using System;
using System.Data.Entity;

namespace BookstoreNetworkSystem
{
    public class MyDbContext : DbContext
    {

        public MyDbContext() : base("DbConnectionString")
        { }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BookStore> BookStores { get; set; }
    }
}
