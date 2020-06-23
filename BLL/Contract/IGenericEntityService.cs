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
        Task<TDto> Add(TDto entity);
        Task AddRange(IEnumerable<TDto> entities);
        Task<IEnumerable<TDto>> GetAll();
        Task<TDto> GetById(int id);
        Task Remove(TDto entity);
        Task RemoveRange(IEnumerable<TDto> entities);
        Task Update(TDto entity);
    }
}

