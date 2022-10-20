using CQRSDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSDemo
{
    public class ApplicationContext: DbContext, IApplicationContext
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
    }
}
