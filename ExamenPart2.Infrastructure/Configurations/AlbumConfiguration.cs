using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ExamenPart2.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamenPart2.Infrastructure.Configurations
{
    public class AlbumConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album>builder)
        {
            builder.HasKey(x => x.id);
            builder.Property(x => x.id).ValueGeneratedOnAdd();
            builder.Property(x => x.albumName).IsRequired();
            builder.Property(x => x.artistName).IsRequired();
            builder.Property(x => x.bought).IsRequired();
            builder.Property(x => x.description).IsRequired();
            builder.Property(x => x.price).IsRequired();
            builder.Property(x => x.score).IsRequired();
            
        }

    }
}
