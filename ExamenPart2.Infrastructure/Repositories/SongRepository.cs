using System;
using System.Collections.Generic;
using System.Text;
using ExamenPart2.Core.Interfaces;
using ExamenPart2.Core.Entities;
using System.Linq;
using ExamenPart2.Core;

namespace ExamenPart2.Infrastructure.Repositories
{
    public class SongRepository: EntityFrameworkRepository<Song>, ISongRepository
    {
        public SongRepository(ExamenPart2DbContext examenPart2DbContext)
            : base(examenPart2DbContext)
        {
        }

        public Song AddSong_and_Update_Popularity_Price_FromAlbum(Song bodySong)
        {
            //get songs from selected album with same id of the new song
            var songsinAlbum = _ExamenPart2DbContext.Songs.Where(x => x.albumId == bodySong.albumId);
            // score of album popularity - 10%
            var score = songsinAlbum.Sum(x => x.popularity) / songsinAlbum.Count();
           
            var modifiedAlbum = _ExamenPart2DbContext.Albums.FirstOrDefault(x => x.id == bodySong.albumId);
            modifiedAlbum.score = score;
            var fullAlbumprice = songsinAlbum.Sum(x => x.price) + bodySong.price;
            modifiedAlbum.price = fullAlbumprice - (fullAlbumprice * 0.1);

            _ExamenPart2DbContext.Songs.Add(bodySong);
            _ExamenPart2DbContext.SaveChanges();
            _ExamenPart2DbContext.Albums.Update(modifiedAlbum);
            _ExamenPart2DbContext.SaveChanges();

            return bodySong;

        }

    }
}
