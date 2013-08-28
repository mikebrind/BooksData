using System;
using System.ComponentModel.DataAnnotations;

namespace BooksData.Entities
{
    public class Book
    {
        public int BookId { get; set; }
        [MaxLength(200)]
        public string Title { get; set; }
        public string Description { get; set; }
        [MaxLength(20)]
        public string ISBN { get; set; }
        public DateTime DatePublished { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Author Author { get; set; }
    }
}
