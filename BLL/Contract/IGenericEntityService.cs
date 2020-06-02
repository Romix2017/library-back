using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Contract
{
    public interface IGenericEntityService<TDto>
    {
        Task<ActionResult> Add(TDto entity);
        Task<ActionResult> AddRange(IEnumerable<TDto> entities);
        Task<ActionResult<IEnumerable<TDto>>> GetAll();
        Task<ActionResult<TDto>> GetById(int id);
        Task<ActionResult> Remove(TDto entity);
        Task<ActionResult> RemoveRange(IEnumerable<TDto> entities);
        Task<ActionResult> Update(TDto entity);
    }
}

