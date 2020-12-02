using ExamenPart2.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExamenPart2.Core.Interfaces
{
    public interface ISongRepository
    {
        Song AddSong(Song bodySong);
    }
}
