using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Books.Core.Models
{
    [Index(nameof(Name))]
    public class Genre
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }


        public virtual List<Book> Books { get; set; }


        public override string ToString()
        {
            return string.Format("{0}", Name);
        }

        


    }
}
