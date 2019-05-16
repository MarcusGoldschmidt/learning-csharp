using System.Collections;
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
    public class AuthorController
    {
        // Opção para não ocorer referencia circular
        private JsonSerializerSettings JsonSettings = new JsonSerializerSettings()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };
        
        // GET api/values
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var response = await new MainContext()
                .Authors
                .Include(e => e.Books)
                /*.Take(100)
                .Skip(0)*/
                .ToListAsync();

            var json = JsonConvert.SerializeObject(response, JsonSettings);

            return new ObjectResult(json);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<string> Get(int id)
        {
            MainContext db = new MainContext();

            var response = await db.Authors
                .Include(e => e.Books)
                .SingleOrDefaultAsync(x => x.AuthorId == id);
            
            return JsonConvert.SerializeObject(response, JsonSettings);
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