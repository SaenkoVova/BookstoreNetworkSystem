using System.Collections.Generic;

namespace BookstoreNetworkSystem.models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public double Price { get; set; }
        public string Date { get; set; }
        public ICollection<BookStore> BookStores { get; set; }
        public ICollection<User> Users { get; set; }
        public virtual Author Author { get; set; }
        public Book()
        {
            BookStores = new List<BookStore>();
            Users = new List<User>();
        }
    }
}
