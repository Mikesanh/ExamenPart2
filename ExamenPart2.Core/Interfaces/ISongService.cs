using ExamenPart2.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenPart2.Core.Interfaces
{
    public interface ISongService
    {
     

        //IRepository<Song> SongRepository { get; set; }

        void getSongs();
        void addSong();


    }
}
