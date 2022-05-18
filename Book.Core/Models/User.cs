using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Books.Core.Models
{
    public class User
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Key { get; set; }

        [MaxLength(100)]
        public string Image { get; set; }


        public List<Book> Books { get; set; }

    }
}
