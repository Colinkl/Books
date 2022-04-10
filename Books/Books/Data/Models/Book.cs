using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Books.Data.Models
{
    public class Book
    {
        public int Id { get; set; } 

        public string Name { get; set; }

        public string Descripton { get; set; }

        public string Image { get; set; }

        public List<Author> Authors { get; set; }

        public List<Genre> Genres { get; set; }

        public int LocationId { get; set; }

        public Location Location { get; set; }

        [ForeignKey("AddedByUserId")]
        public User AddedBy { get; set; }

    }
}
