using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ExamenPart2.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExamenPart2.Infrastructure.Configurations
{
    
    public class SongConfiguration:IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.HasKey(x => x.sid);
            builder.Property(x => x.sid).ValueGeneratedOnAdd();
            builder.Property(x => x.songName).IsRequired();
            builder.Property(x => x.artistName).IsRequired();
            builder.Property(x => x.bought).IsRequired();
            builder.Property(x => x.price).IsRequired();
            builder.Property(x => x.duration).IsRequired();
            builder.Property(x => x.popularity).IsRequired();
        }
    }
}
