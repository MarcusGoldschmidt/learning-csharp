using System.ComponentModel.DataAnnotations;

namespace FistApi.Models
{
    public class Author
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
    }
}