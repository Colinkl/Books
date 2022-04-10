using System;
using System.Collections.Generic;
using System.Text;

namespace Books.Data.Models
{
    public class Location
    {
        public int Id { get; set; }

        public int Row { get; set; }

        public int Shelf { get; set; }

        public int Rack { get; set; }

        public Book Book { get; set; }
    }
}
