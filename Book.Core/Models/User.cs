using System.Collections.Generic;

namespace Books.Core.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Key { get; set; }

        public string Image { get; set; }

        public virtual List<Book> Books { get; set; }

    }
}
