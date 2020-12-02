using ExamenPart2.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenPart2.Core.Interfaces
{
    public interface ISongService
    {
     

       

        ServiceResult<IEnumerable<Song>> getSongs();
        ServiceResult<Song> GetSongbyId(int id);
        ServiceResult<Song> AddSong(Song bodySong);




    }
}
