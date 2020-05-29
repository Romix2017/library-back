using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.contract
{
    public interface IBooksHistoryService<T, TDto>
    {
        Task<ActionResult> Add(T entity);
        Task<ActionResult> AddRange(IEnumerable<T> entities);
        Task<ActionResult<IEnumerable<T>>> Find(Expression<Func<T, bool>> predicate);
        Task<ActionResult<IEnumerable<TDto>>> GetAll();
        Task<ActionResult<T>> GetById(int id);
        Task<ActionResult> Remove(T entity);
        Task<ActionResult> RemoveRange(IEnumerable<T> entities);
    }
}
