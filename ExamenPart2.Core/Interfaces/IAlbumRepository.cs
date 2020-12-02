using ExamenPart2.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ExamenPart2.Core.Interfaces
{
    public interface IAlbumRepository
    {
        IEnumerable<Album>GetPopularAlbums();


    }
}
