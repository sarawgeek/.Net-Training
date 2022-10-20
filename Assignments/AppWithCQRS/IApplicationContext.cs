using AppWithCQRS.Models;
using Microsoft.EntityFrameworkCore;

namespace AppWithCQRS
{
    public interface IApplicationContext
    {
        DbSet<AWB> AWBs { get; set; }

        Task<int> SaveChanges();
    }
}