using Microsoft.EntityFrameworkCore;
using ExamenPart2.Infrastructure.Configurations;
using ExamenPart2.Core.Entities;

using System;

namespace ExamenPart2.Infrastructure
{
    public class ExamenPart2DbContext:DbContext
    {
      public ExamenPart2DbContext(DbContextOptions options):
            base(options)
        {

        }
        public DbSet<Album> Albums { get; set; }

        public DbSet<Song> Songs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlbumConfiguration());
            modelBuilder.ApplyConfiguration(new SongConfiguration());

        }
    }
}
