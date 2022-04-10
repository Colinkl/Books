using System;
using System.Collections.Generic;
using System.Text;

namespace Books.Core.Models
{
    public class StorageUnit
    {
        public int Id { get; set; }

        public int Row { get; set; }

        public int Shelf { get; set; }

        public int Rack { get; set; }

        public Book Book { get; set; }
    }
}
