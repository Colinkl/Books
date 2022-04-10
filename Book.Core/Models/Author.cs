using System;
using System.Collections.Generic;
using System.Text;

namespace Books.Core.Models
{
    public class Author
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public List<Book> BookList { get; set; } = new List<Book>();


    }
}
