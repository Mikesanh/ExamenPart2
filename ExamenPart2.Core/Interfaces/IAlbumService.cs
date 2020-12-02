using ExamenPart2.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;


namespace ExamenPart2.Core.Interfaces
{
    public interface IAlbumService
    {
         ServiceResult<IEnumerable<Album>> GetAlbums();

        ServiceResult<IEnumerable<Album>> GetPopularAlbums();

        ServiceResult<Album> GetAlbumbyId(int id);

        ServiceResult<Album> AddAlbum(Album bodyAlbum);



    }
}
