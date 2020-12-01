using System;
using System.Collections.Generic;
using System.Text;
using ExamenPart2.Core.Interfaces;
using ExamenPart2.Core.Entities;



namespace ExamenPart2.Core.Services
{
    public class SongService : ISongService
    {
        public IRepository<Song> _songRepository;

        public SongService(IRepository<Song> songRepository)
        {
            _songRepository = songRepository;
        }

        public void addSong()
        {
          
            
        }

        public void getSongs()
        {
            throw new NotImplementedException();
        }
    }
}
