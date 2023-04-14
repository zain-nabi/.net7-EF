using Application.Model;
using Microsoft.EntityFrameworkCore;

namespace Application.Model
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Events> Events { get; set; }
    }
}