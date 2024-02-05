using Proiect.Models;
using Proiect.Models.LeagueData;
using Microsoft.EntityFrameworkCore;

namespace Proiect.Data
{
    public class ProiectContext: DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Champion> Champions { get; set; }

        public DbSet<SelectedChampions> SelectedChampions { get; set; }

        public DbSet<Icons> Icons { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<ModelsRelation> ModelsRelations { get; set; }
        public ProiectContext(DbContextOptions<ProiectContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Champion - Selected Champions - One to many
            modelBuilder.Entity<Champion>()
                        .HasMany(c => c.SelectedChampions)
                        .WithOne(sc => sc.Champion);
            
            // icon - champion - one to one
            modelBuilder.Entity<Icons>()
                .HasOne(i => i.Champion)
                .WithOne(c => c.Icon)
                .HasForeignKey<Champion>(c => c.IconID);

            // icon - item - one to one
            modelBuilder.Entity<Icons>()
                .HasOne(i => i.Item)
                .WithOne(i2 => i2.Icon)
                .HasForeignKey<Item>(i2 => i2.IconID);

            // item - selected champions - many to many
            modelBuilder.Entity<ModelsRelation>().HasKey(mr => new { mr.SelectedChampId, mr.ItemId });

            modelBuilder.Entity<ModelsRelation>()
                        .HasOne(mr => mr.SelectedChampions)
                        .WithMany(sc => sc.ModelsRelations)
                        .HasForeignKey(mr => mr.SelectedChampId);

            modelBuilder.Entity<ModelsRelation>()
                        .HasOne(mr => mr.Item)
                        .WithMany(i => i.ModelsRelations)
                        .HasForeignKey(mr => mr.ItemId);


            base.OnModelCreating(modelBuilder);
        }
    }
}
