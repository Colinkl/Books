﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Books.Core.Models
{
    public class Author
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength (50)]
        public string LastName { get; set; }



        public virtual List<Book> BookList { get; set; } = new List<Book>();


        public string FullName
        {
            get => string.Format("{0} {1}", Name, LastName);
        }
        public override string ToString()
        {
            return string.Format("{0} {1}", Name, LastName);
        }

    }
}
