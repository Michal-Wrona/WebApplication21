using Microsoft.EntityFrameworkCore;
using WebApplication21.Core.Entities;

namespace WebApplication21.Core.Data
{
    public class WebApplication21DbContext : DbContext
    {
        public WebApplication21DbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
