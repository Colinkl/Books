using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Books.Core.Models
{
    [Index(nameof(Title))]
    public class Book
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(500)]
        public string Descripton { get; set; }

        [MaxLength(100)]
        public string Image { get; set; }


        public List<Author> Authors { get; set; } = new List<Author>();

        public List<Genre> Genres { get; set; }

        public int LocationId { get; set; }

        public StorageUnit Location { get; set; }

        [ForeignKey("User")]
        public int AddedByUserId { get; set; }
        public User AddedBy { get; set; }


        public override bool Equals(object obj)
        {
            if (obj is Book book) 
                return Title == book.Title;
            return false;
        }
        public override int GetHashCode() => Title.GetHashCode();
    }
}
