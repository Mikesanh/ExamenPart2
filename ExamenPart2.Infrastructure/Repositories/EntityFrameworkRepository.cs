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
            return _ExamenPart2DbContext.Set<T>().FirstOrDefault(x => x.id == id);
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

       
    }
}
