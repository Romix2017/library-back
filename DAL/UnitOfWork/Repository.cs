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
    public class Repository<T, TDto> : IRepository<T, TDto> where T : class where TDto : class
    {
        internal readonly DbSet<T> _entities;
        private readonly DbContext _context;
        public Repository(DbContext context)
        {
            _entities = context.Set<T>();
            _context = context;
        }
        public T Add(T entity)
        {
            _entities.Add(entity);
            return entity;
        }

        public T Update(T entity)
        {
            _entities.Update(entity);
            return entity;
        }

        public IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            _entities.AddRange(entities);
            return entities;
        }

        public async Task<IEnumerable<TDto>> Find(Expression<Func<T, bool>> predicate)
        {
            var res = await _entities.Where(predicate).ToListAsync();
            return Mapping.Mapper.Map<IEnumerable<TDto>>(res);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }
        public async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }

        public T Remove(T entity)
        {
            _entities.Remove(entity);
            return entity;
        }

        public IEnumerable<T> RemoveRange(IEnumerable<T> entities)
        {
            _entities.RemoveRange(entities);
            return entities;
        }

        //DTO
        public async Task<TDto> GetByIdDTO(int id)
        {
            var res = await _entities.FindAsync(id);
            return Mapping.Mapper.Map<TDto>(res);
        }
        public async Task<IEnumerable<TDto>> GetAllDTO()
        {
            var res = await _entities.ToListAsync();
            return Mapping.Mapper.Map<IEnumerable<TDto>>(res);
        }
        public TDto AddDTO(TDto entity)
        {
            T res = Mapping.Mapper.Map<T>(entity);
            _entities.Add(res);
            this._context.SaveChanges();
            var resDto = Mapping.Mapper.Map<TDto>(res);
            return resDto;
        }
        public IEnumerable<TDto> AddRangeDTO(IEnumerable<TDto> entities)
        {
            var res = Mapping.Mapper.Map<IEnumerable<T>>(entities);
            _entities.AddRange(res);
            return entities;
        }
        public TDto RemoveDTO(TDto entity)
        {
            var res = Mapping.Mapper.Map<T>(entity);
            _entities.Remove(res);
            return entity;
        }
        public IEnumerable<TDto> RemoveRangeDTO(IEnumerable<TDto> entities)
        {
            var res = Mapping.Mapper.Map<IEnumerable<T>>(entities);
            _entities.RemoveRange(res);
            return entities;
        }
        public TDto UpdateDTO(TDto entity)
        {
            var res = Mapping.Mapper.Map<T>(entity);
            _entities.Update(res);
            return entity;
        }
    }
}
