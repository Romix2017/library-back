using DAL.Automapper;
using DAL.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
   public class Repository<T, TDto>: IRepository<T, TDto> where T: class where TDto: class
    {
        private readonly DbSet<T> _entities;
        public Repository(DbContext context)
        {
            _entities = context.Set<T>();
        }
        public void Add(T entity)
        {
            _entities.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _entities.AddRange(entities);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _entities.Where(predicate);
        }

        public async Task<IEnumerable<TDto>> GetAll()
        {
            var res = await _entities.ToListAsync();
            return Mapping.Mapper.Map<IEnumerable<TDto>>(res);
        }

        public T GetById(int id)
        {
            return _entities.Find(id);
        }

        public void Remove(T entity)
        {
            _entities.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _entities.RemoveRange(entities);
        }
    }
}
