using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FistApi.Database.Migrations;
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
            return new MainContext().Books.ToList();
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
        public async Task<ActionResult<Book>> Post([FromForm]Book value)
        {
            MainContext db = new MainContext();
            var response = db.Books.Add(value).Entity;
            await db.SaveChangesAsync();
            return new ObjectResult(response);
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