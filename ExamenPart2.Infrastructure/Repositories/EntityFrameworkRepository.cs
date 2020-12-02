using ExamenPart2.Core.Entities;
using ExamenPart2.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ExamenPart2.Infrastructure.Repositories
{
    public class EntityFrameworkRepository<T> : IRepository<T> where T : BaseEntity
    {
        public readonly ExamenPart2DbContext _ExamenPart2DbContext;

        public EntityFrameworkRepository(ExamenPart2DbContext ExamenPart2DbContext)
        {
            _ExamenPart2DbContext = ExamenPart2DbContext;
        }

        public IEnumerable<T> GetAll()
        {
            return _ExamenPart2DbContext.Set<T>().ToList();
        }

        public IEnumerable<T> Filter(Expression<Func<T, bool>> predicate)
        {
            return _ExamenPart2DbContext.Set<T>().Where(predicate).ToList();
        }

        public T GetById(int id)
        {
            return _ExamenPart2DbContext.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public T Add(T entity)
        {

            _ExamenPart2DbContext.Add(entity);
            _ExamenPart2DbContext.SaveChanges();
            return entity;
        }

        public void Update(T entity)
        {
            _ExamenPart2DbContext.Entry(entity).State = EntityState.Modified;
            _ExamenPart2DbContext.SaveChanges();
        }

        public int SaveChanges()
        {
            return _ExamenPart2DbContext.SaveChanges();
        }

        //public void AddSong(Song bodySong)
        //{
        //    Song nSong = new Song
        //    {
        //        albumId = bodySong.albumId,
        //        artistName = bodySong.artistName,
        //        bought = bodySong.bought,
        //        duration = bodySong.duration,
        //        popularity = bodySong.popularity,
        //        price = bodySong.price,
        //        sid = bodySong.sid,
        //        songName = bodySong.songName,
        //    };

        //    var songsinAlbum = _ExamenPart2DbContext.Songs.Where(x => x.albumId == bodySong.albumId);
        //    var score = songsinAlbum.Sum(x => x.popularity) / songsinAlbum.Count();
        //    _ExamenPart2DbContext.Songs.Add(nSong);
        //    _ExamenPart2DbContext.SaveChanges();

        //    var modifiedAlbum = _ExamenPart2DbContext.Albums.FirstOrDefault(x => x.id == nSong.albumId);
        //    modifiedAlbum.score = score;
        //    var fullAlbumprice = songsinAlbum.Sum(x => x.price) + nSong.price;
        //    modifiedAlbum.price = fullAlbumprice - (fullAlbumprice * 0.1);

        //    _ExamenPart2DbContext.Albums.Update(modifiedAlbum);
        //    _ExamenPart2DbContext.SaveChanges();
        //}

        //public Album AddAlbum(Album bodyAlbum)
        //{
        //    Album nAlbum = new Album
        //    {
        //        albumName = bodyAlbum.albumName,
        //        artistName = bodyAlbum.artistName,
        //        bought = bodyAlbum.bought,
        //        date = bodyAlbum.date,
        //        score = bodyAlbum.score,
        //        description = bodyAlbum.description,
        //        genre = bodyAlbum.genre,
        //        id = bodyAlbum.id,
        //        image = bodyAlbum.image,
        //        price = bodyAlbum.price,
        //        songs = bodyAlbum.songs,
        //    };

        //    _ExamenPart2DbContext.Albums.Add(nAlbum);
        //    _ExamenPart2DbContext.SaveChanges();
            
        //}

        //public IEnumerable<Album> GetPopularAlbums() 
        //{
        //    var myAlbums = _ExamenPart2DbContext.Albums;
        //    var mostPopularAlbums = _ExamenPart2DbContext.Albums.OrderByDescending(x => x.score).Take(10);
        //    return mostPopularAlbums;
            
        //    //IEnumerable<Album> Top10MostPopularAlbums = new IEnumerable<Album>();
        //    //Album nAlbum = new Album();

        //    //foreach (var item in mostPopularAlbums)
        //    //{

        //    //    nAlbum.albumName = item.albumName;
        //    //    nAlbum.artistName = item.artistName;
        //    //    nAlbum.bought = item.bought;
        //    //    nAlbum.date = item.date;
        //    //    nAlbum.score = item.score;
        //    //    nAlbum.description = item.description;
        //    //    nAlbum.genre = item.genre;
        //    //    nAlbum.id = item.id;
        //    //    nAlbum.image = item.image;
        //    //    nAlbum.price = item.price;
        //    //    nAlbum.songs = item.songs;

        //    //    Top10MostPopularAlbums.Add(nAlbum);

        //    //}


        //    //return Top10MostPopularAlbums;
        //}
    }
}
