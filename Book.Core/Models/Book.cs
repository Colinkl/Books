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

        public virtual List<Author> Authors { get; set; } = new List<Author>();

        public virtual List<Genre> Genres { get; set; }

        public int LocationId { get; set; }

        public virtual StorageUnit Location { get; set; }

        [ForeignKey("User")]
        public int AddedByUserId { get; set; }
        public virtual User AddedBy { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is Book book) 
                return Title == book.Title;
            return false;
        }
        public override int GetHashCode() => Title.GetHashCode();
    }
}
