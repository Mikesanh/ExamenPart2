using ExamenPart2.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenPart2.Core.Interfaces
{
    public interface ISongRepository
    {
        Song AddSong_and_Update_Popularity_Price_FromAlbum(Song bodySong);
    }
}
