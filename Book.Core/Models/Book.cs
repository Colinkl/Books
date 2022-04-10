using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Books.Core.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Descripton { get; set; }

        public string Image { get; set; }

        public List<Author> Authors { get; set; }  = new List<Author>();

        public List<Genre> Genres { get; set; }

        public int LocationId { get; set; }

        public StorageUnit Location { get; set; }

        [ForeignKey("User")]
        public int AddedByUserId { get; set; }
        public User AddedBy { get; set; }

    }
}
