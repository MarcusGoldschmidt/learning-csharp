using System.Collections;
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
        public ActionResult<IList> Get()
        {
            return books;
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
        public ActionResult<Book> Post([FromForm]Book value)
        {
            value.id = books.Count + 1;
            books.Add(value);
            return new ObjectResult(books);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromForm] string value)
        {
            
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}