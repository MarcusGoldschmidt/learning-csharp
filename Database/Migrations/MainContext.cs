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
            // SQL LITE
            // .UseSqlite("Data Source=db_livraria.db");

            optionsBuilder
                .UseMySql("Server=localhost;Database=db_livraria;Uid=root;Pwd=55");
        }
    }
}