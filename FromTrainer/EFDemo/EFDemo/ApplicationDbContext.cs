using EFDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace EFDemo
{
    public class ApplicationDbContext: DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

    }
}
