using System.Collections.Generic;

namespace BookstoreNetworkSystem.models
{
    public class User
    {
        public int Id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public bool status { get; set; }
        public ICollection<Book> Books { get; set; }
        public User()
        {
            Books = new List<Book>();
        }

    }
}
