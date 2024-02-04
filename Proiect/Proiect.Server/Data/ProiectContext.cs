using Proiect.Models;
using Microsoft.EntityFrameworkCore;

namespace Proiect.Data
{
    public class ProiectContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public ProiectContext(DbContextOptions<ProiectContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            base.OnModelCreating(modelBuilder);
        }
    }
}
