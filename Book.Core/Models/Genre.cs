using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Books.Core.Models
{
    public class Genre
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }


        public virtual List<Book> Books { get; set; }


        public override string ToString()
        {
            return String.Format("{0}", Name);
        }

        


    }
}
