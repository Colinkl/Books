using System;

namespace Books.Core.Models
{
    public class StorageUnit
    {
        public int Id { get; set; }

        public int Row { get; set; }

        public int Shelf { get; set; }

        public int Rack { get; set; }

        public override string ToString()
        {
            return String.Format("rack {0}, row {1}, shelf {2}", this.Rack, this.Row, this.Shelf);
        }

        public virtual Book Book { get; set; }
    }
}
