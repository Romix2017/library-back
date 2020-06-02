using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public interface IRepository<T, TDto> where T : class where TDto : class
    {
        //Ent
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<TDto>> Find(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        IEnumerable<T> AddRange(IEnumerable<T> entities);
        T Remove(T entity);
        T Update(T entity);
        IEnumerable<T> RemoveRange(IEnumerable<T> entities);
        //DTO
        Task<TDto> GetByIdDTO(int id);
        Task<IEnumerable<TDto>> GetAllDTO();
        TDto AddDTO(TDto entity);
        IEnumerable<TDto> AddRangeDTO(IEnumerable<TDto> entities);
        TDto RemoveDTO(TDto entity);
        IEnumerable<TDto> RemoveRangeDTO(IEnumerable<TDto> entities);
        TDto UpdateDTO(TDto entity);
    }
}
