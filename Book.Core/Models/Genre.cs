using System;
using System.Collections.Generic;

namespace Books.Core.Models
{
    public class Genre
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return String.Format("{0}", Name);
        }

        public virtual List<Book> Books { get; set; }


    }
}
