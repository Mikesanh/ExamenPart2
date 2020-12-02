using System;
using System.Collections.Generic;
using System.Text;
using ExamenPart2.Core.Entities;
using ExamenPart2.Core.Interfaces;
namespace ExamenPart2.Core.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IRepository<Album> _albumRepository;
        private readonly IAlbumRepository _ialbumRepository;


        public AlbumService(IRepository<Album> albumRepository, IAlbumRepository ialbumrepository)
        {
            _albumRepository = albumRepository;
            _ialbumRepository = ialbumrepository;
        }

        public ServiceResult<IEnumerable<Album>> GetAlbums()
        {
            return ServiceResult<IEnumerable<Album>>.SuccessResult(_albumRepository.GetAll());
        }
        public ServiceResult<IEnumerable<Album>> GetPopularAlbums()
        {
            return ServiceResult<IEnumerable<Album>>.SuccessResult(_ialbumRepository.GetPopularAlbums());
        }
        public ServiceResult<Album>GetAlbumbyId(int id)
        {
            return ServiceResult<Album>.SuccessResult(_albumRepository.GetById(id));
        }

        public ServiceResult<Album> AddAlbum(Album bodyAlbum)
        {
            return ServiceResult<Album>.SuccessResult(_albumRepository.Add(bodyAlbum));

        }


    }
}
