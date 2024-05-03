﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ISBN { get; set; }
        public DateTime PublicationDate { get; set; }
        public decimal Price { get; set; }
        public string Language { get; set; }
        public string Publisher { get; set; }
        public int PageCount { get; set; }
        public float AverageRating { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int GenreId { get; set; }

        public Book()
        {
         
        }
    }
}
