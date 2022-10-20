using JWTDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace JWTDemo
{
    public class ApplicationDbContext: DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        public DbSet<Book> Book { get; set; }
        public DbSet<User> User { get; set; }
    }
}
