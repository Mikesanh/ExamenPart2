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
        public ISongRepository _isongRepository;

        public SongService(IRepository<Song> songRepository, ISongRepository isongRepository)
        {
            _songRepository = songRepository;
            _isongRepository=isongRepository;
        }
        public ServiceResult<IEnumerable<Song>> getSongs()
        {
            return ServiceResult<IEnumerable<Song>>.SuccessResult(_songRepository.GetAll());
        }
        public ServiceResult<Song> GetSongbyId(int id)
        {
            return ServiceResult<Song>.SuccessResult(_songRepository.GetById(id));
        }

        public ServiceResult<Song> AddSong(Song bodySong)
        {
            return ServiceResult<Song>.SuccessResult(_isongRepository.AddSong(bodySong));

        }
    }
}
