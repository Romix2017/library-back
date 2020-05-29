using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public interface IRepository<T, TDto> where T : class where TDto : class
    {
        Task<T> GetById(int id);
        Task<IEnumerable<TDto>> GetAll();
        Task<IEnumerable<TDto>> Find(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        IEnumerable<T> AddRange(IEnumerable<T> entities);
        T Remove(T entity);
        IEnumerable<T> RemoveRange(IEnumerable<T> entities);
    }
}
