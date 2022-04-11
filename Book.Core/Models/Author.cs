using System.Collections.Generic;

namespace Books.Core.Models
{
    public class Author
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public virtual List<Book> BookList { get; set; } = new List<Book>();

        public override string ToString()
        {
            return string.Format("{0} {1}", Name, LastName);
        }

    }
}
