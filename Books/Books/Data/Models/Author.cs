﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Books.Data.Models
{
    public class Author
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public List<Book> Books { get; set; }


    }
}