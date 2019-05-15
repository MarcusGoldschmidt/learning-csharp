using System;
using System.ComponentModel.DataAnnotations;

namespace FistApi.Models
{
    public class Book
    {
        public Book()
        {
            is_using = false;
            start_time = DateTime.Now;
        }
        
        public int id { get; set; }
        
        public Boolean is_using { get; set; }
        
        [Required]
        [MinLength(5)]
        public string name { get; set; }
        
        [Required]
        public string author { get; set; }
        
        [Required]
        public string publishing { get; set; }
        
        public DateTime start_time { get; set; }
        
        public DateTime finish_time { get; set; }
    }
}