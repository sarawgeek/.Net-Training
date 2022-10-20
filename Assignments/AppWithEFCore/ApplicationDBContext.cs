using AppWithEFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace AppWithEFCore
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<AWB> AWBs { get; set; }

    }
}
