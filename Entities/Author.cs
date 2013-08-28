using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BooksData.Entities
{
    public class Author
    {
        public int AuthorId { get; set; }
        [MaxLength(35)]
        public string FirstName { get; set; }
        [MaxLength(35)]
        public string LastName { get; set; }
        public string Biography { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
