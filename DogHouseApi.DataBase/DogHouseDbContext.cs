using DogHouseApi.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace DogHouseApi.DataBase
{
    public class DogHouseDbContext : DbContext
    {
        public DbSet<Dog> Dogs { get; set; }

        public DogHouseDbContext(DbContextOptions<DogHouseDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Dog>(entity =>
            {
                entity.HasKey(d => d.Name);
                entity.Property(d => d.Name).HasColumnName("name");
                entity.Property(d => d.Color).HasColumnName("color");
                entity.Property(d => d.TailLength).HasColumnName("tail_length").HasColumnType("integer");
                entity.Property(d => d.Weight).HasColumnName("weight").HasColumnType("integer");
            });
        }
    }
}