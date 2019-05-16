using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FistApi.Database.Migrations;
using FistApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace FistApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        // Opção para não ocorer referencia circular
        private JsonSerializerSettings JsonSettings = new JsonSerializerSettings()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
        };
        
        // GET api/values
        [HttpGet]
        public async Task<string> Get()
        {
            var response = await new MainContext()
                .Books
                .Include(e => e.Author)
                .ToListAsync();

            return JsonConvert.SerializeObject(response, JsonSettings);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<string> Get(int id)
        {
            MainContext db = new MainContext();
            var response = await db.Books
                .Include(e => e.Author)
                .SingleOrDefaultAsync(e => e.BookId == id);
            
            return JsonConvert.SerializeObject(response, JsonSettings);
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
        [HttpPut]
        public async Task<Book> Put([FromForm] Book value)
        {
            MainContext db = new MainContext();
            db.Books.Update(value);
            await db.SaveChangesAsync();
            return value;
        }

        // DELETE api/values/5
        [HttpDelete]
        public async Task<Book> Delete([FromForm] int id)
        {
            MainContext db = new MainContext();
            var respose = await db.Books.FindAsync(id);
            db.Books.Remove(respose);
            await db.SaveChangesAsync();
            
            return respose; 
        }
    }
}