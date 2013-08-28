using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BooksData.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        [MaxLength(50)]
        public string CategoryName { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
