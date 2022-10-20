using CQRSDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSDemo
{
    public interface IApplicationContext
    {

        DbSet<User> Users { get; set;  }

        Task<int> SaveChanges();
    }
}
