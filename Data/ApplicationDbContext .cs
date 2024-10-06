using Microsoft.EntityFrameworkCore;
using WorkPoint_WebApp.Entities.Models;

namespace WorkPoint_WebApp.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<News> News { get; set; }
    }

}
