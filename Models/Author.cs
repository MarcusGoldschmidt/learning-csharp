using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FistApi.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public int age { get; set; }
        
        public IList<Book> Books { get; set; }
    }
}