using BLL.Contract;
using DAL.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public abstract class AbstractGenericEntityService<T, TDto> : IGenericEntityService<TDto> where T : class where TDto : class
    {
        internal readonly IUnitOfWork _unitOfWork;
        public AbstractGenericEntityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ActionResult> Add(TDto entity)
        {
            try
            {
                await Task.FromResult<TDto>(_unitOfWork.GetRepo<T, TDto>(typeof(TDto)).AddDTO(entity));
                return new OkResult();
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ActionResult> AddRange(IEnumerable<TDto> entities)
        {
            try
            {
                await Task.FromResult<IEnumerable<TDto>>(_unitOfWork.GetRepo<T, TDto>(typeof(TDto)).AddRangeDTO(entities));
                return new OkResult();
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ActionResult<IEnumerable<TDto>>> GetAll()
        {
            try
            {
                return new OkObjectResult(await _unitOfWork.GetRepo<T, TDto>(typeof(TDto)).GetAllDTO());
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ActionResult<TDto>> GetById(int id)
        {
            try
            {
                return new OkObjectResult(await _unitOfWork.GetRepo<T, TDto>(typeof(TDto)).GetById(id));
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ActionResult> Remove(TDto entity)
        {
            try
            {
                await Task.FromResult<TDto>(_unitOfWork.GetRepo<T, TDto>(typeof(TDto)).RemoveDTO(entity));
                return new OkResult();
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ActionResult> RemoveRange(IEnumerable<TDto> entities)
        {
            try
            {
                await Task.FromResult<IEnumerable<TDto>>(_unitOfWork.GetRepo<T, TDto>(typeof(TDto)).RemoveRangeDTO(entities));
                return new OkResult();
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ActionResult> Update(TDto entity)
        {
            try
            {
                await Task.FromResult<TDto>(_unitOfWork.GetRepo<T, TDto>(typeof(TDto)).UpdateDTO(entity));
                return new OkResult();
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
