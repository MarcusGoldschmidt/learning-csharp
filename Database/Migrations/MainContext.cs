using System.Configuration;
using FistApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FistApi.Database.Migrations
{
    public class MainContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        
        public DbSet<Book> Books { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>();
            modelBuilder.Entity<Book>();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlite("Data Source=db_livraria.db");
            // .UseMySQL(ConfigurationManager.ConnectionStrings["LivrariaDatabase"].ConnectionString)
        }
    }
}