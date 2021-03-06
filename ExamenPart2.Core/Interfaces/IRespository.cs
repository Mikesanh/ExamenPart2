﻿using ExamenPart2.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ExamenPart2.Core.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();

        IEnumerable<T> Filter(Expression<Func<T, bool>> predicate);

        T GetById(int id);

        T Add(T entity);

        void Update(T entity);

        int SaveChanges();

        //public void AddSong(Song bodySong);

        //public Album AddAlbum(Album bodyAlbum);

        //IEnumerable<Album> GetPopularAlbums();
    }
}
