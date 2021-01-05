using System.Collections.Generic;

namespace BookstoreNetworkSystem.models
{
    public class BookStore
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public byte[] Image { get; set; }
        public ICollection<Book> Books { get; set; }
        public BookStore()
        {
            Books = new List<Book>();
        }
    }
}
