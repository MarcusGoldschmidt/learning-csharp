using System;
using System.ComponentModel.DataAnnotations;

namespace FistApi.Models
{
    public class Book
    {
        public Book()
        {
            Is_using = false;
            Start_time = DateTime.Now;
        }
        
        public int id { get; set; }
        
        public Boolean Is_using { get; set; }
        
        [Required]
        [MinLength(5)]
        public string Title { get; set; }
        
        [Required]
        public string Publishing { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Start_time { get; set; }
        
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Finish_time { get; set; }
        
        // Chave
        [Required]
        public int Author_id { get; set; }
        
        public Author Author { get; set; }
    }
}