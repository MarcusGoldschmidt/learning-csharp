using System;
using System.Collections.Generic;
using System.Linq;
using FistApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FistApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private List<Book> books = new List<Book>();

        // GET api/values
        [HttpGet]
        public ActionResult<IList<Book>> Get()
        {
            Book book = new Book();
            book.name = "Marcus";
            book.author = "João";
            book.publishing = "Autora";

            books.Add(book);
            
            Console.WriteLine("\n" + books + "\n");
            
            return new ObjectResult(books);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IEnumerable<Book> Get(int id)
        {
            // Define the query expression.
            IEnumerable<Book> query = from book in books where book.id == id select book;
            
            return query;
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody]Book value)
        {
            value.id = books.Count + 1;
            books.Add(value);
            return new ObjectResult(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}