using System;
using System.Collections.Generic;
using System.Text;

namespace Books.Data.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Key { get; set; }

        public string Image { get; set; }

        public List<Book> Books { get; set; }

    }
}
