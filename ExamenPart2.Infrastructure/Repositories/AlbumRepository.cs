using ExamenPart2.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using ExamenPart2.Core.Interfaces;
using System.Linq;

namespace ExamenPart2.Infrastructure.Repositories
{
    public class AlbumRepository : EntityFrameworkRepository<Album>,IAlbumRepository
    {
        public AlbumRepository(ExamenPart2DbContext examenPart2DbContext)
            : base(examenPart2DbContext)
        {
        }

        public IEnumerable<Album> GetPopularAlbums()
        {
            return _ExamenPart2DbContext.Albums.OrderByDescending(x => x.score).Take(10).ToList(); 

        }

    }
}
