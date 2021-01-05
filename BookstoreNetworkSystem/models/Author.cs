
using System.Collections.Generic;

namespace BookstoreNetworkSystem.models
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
