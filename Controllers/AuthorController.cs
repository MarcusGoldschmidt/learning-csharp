using System.Collections;
using System.Threading.Tasks;
using FistApi.Database.Migrations;
using FistApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FistApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController
    {
        // GET api/values
        [HttpGet]
        public async Task<IList> Get()
        {
            return await new MainContext().Authors.ToListAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Author> Get(int id)
        {
            MainContext db = new MainContext();
            return await db.Authors.FindAsync(id);
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<Author>> Post([FromForm]Author value)
        {
            MainContext db = new MainContext();
            var response = db.Authors.Add(value).Entity;
            await db.SaveChangesAsync();
            return new ObjectResult(response);
        }

        // PUT api/values/5
        [HttpPut]
        public async Task<Author> Put([FromForm] Author value)
        {
            MainContext db = new MainContext();
            db.Authors.Update(value);
            await db.SaveChangesAsync();
            return value;
        }

        // DELETE api/values/5
        [HttpDelete]
        public async Task<Author> Delete([FromForm] int id)
        {
            MainContext db = new MainContext();
            var respose = await db.Authors.FindAsync(id);
            db.Authors.Remove(respose);
            await db.SaveChangesAsync();
            
            return respose; 
        }
    }
}