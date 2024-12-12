using BarnBase.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BarnBase.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
      
        public DbSet<Animal> Animal { get; set; }

        public DbSet<Weight> Weight { get; set; }

        public DbSet<Farm> Farm { get; set; }

        public DbSet<FixedPriceSale> FixedPriceSale { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<Breeding> Breeding { get; set; }

        public DbSet<FavouriteSale> FavouriteSale { get; set; }

        public DbSet<NoteTask> NoteTask { get; set; }

        public DbSet<AnamilImage> AnimalImage { get; set; }

        public DbSet<AnimalDocuments> AnimalDocuments { get; set; }

    }
}
