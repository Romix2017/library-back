using BLL.Contract;
using BLL.Contract.Errors;
using Core.Models.Logging;
using Core.Shared.ErrorCodes;
using Core.Shared.helpers;
using Core.Shared.Helpers;
using DAL.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace BLL.Concrete
{
    public abstract class AbstractGenericEntityService<T, TDto> : IGenericEntityService<TDto> where T : class where TDto : class
    {
        internal readonly IUnitOfWork _unitOfWork;
        internal readonly IErrorService _errorService;
        internal readonly int _moduleCode;
        public AbstractGenericEntityService(IUnitOfWork unitOfWork, IErrorService errorService, int moduleCode)
        {
            _unitOfWork = unitOfWork;
            _errorService = errorService;
            _moduleCode = moduleCode;
        }
        public async Task<ActionResult> Add(TDto entity)
        {
            try
            {
                await Task.FromResult<TDto>(_unitOfWork.GetRepo<T, TDto>(typeof(TDto)).AddDTO(entity));
                SaveToDB();
                return new OkResult();
            }
            catch (Exception ex)
            {
                throw _errorService.CreateException(ex, this._moduleCode, MethodsIndex.ADD);
            }
        }

        public async Task<ActionResult> AddRange(IEnumerable<TDto> entities)
        {
            try
            {
                await Task.FromResult<IEnumerable<TDto>>(_unitOfWork.GetRepo<T, TDto>(typeof(TDto)).AddRangeDTO(entities));
                SaveToDB();
                return new OkResult();
            }
            catch (Exception ex)
            {
                throw _errorService.CreateException(ex, this._moduleCode, MethodsIndex.ADD_RANGE);
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
                throw _errorService.CreateException(ex, this._moduleCode, MethodsIndex.GET_ALL);
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
                throw _errorService.CreateException(ex, this._moduleCode, MethodsIndex.GET_BY_ID);
            }
        }

        public async Task<ActionResult> Remove(TDto entity)
        {
            try
            {
                await Task.FromResult<TDto>(_unitOfWork.GetRepo<T, TDto>(typeof(TDto)).RemoveDTO(entity));
                SaveToDB();
                return new OkResult();
            }
            catch (Exception ex)
            {
                throw _errorService.CreateException(ex, this._moduleCode, MethodsIndex.REMOVE);
            }
        }

        public async Task<ActionResult> RemoveRange(IEnumerable<TDto> entities)
        {
            try
            {
                await Task.FromResult<IEnumerable<TDto>>(_unitOfWork.GetRepo<T, TDto>(typeof(TDto)).RemoveRangeDTO(entities));
                SaveToDB();
                return new OkResult();
            }
            catch (Exception ex)
            {
                throw _errorService.CreateException(ex, this._moduleCode, MethodsIndex.REMOVE_RANGE);
            }
        }

        public async Task<ActionResult> Update(TDto entity)
        {
            try
            {
                await Task.FromResult<TDto>(_unitOfWork.GetRepo<T, TDto>(typeof(TDto)).UpdateDTO(entity));
                SaveToDB();
                return new OkResult();
            }
            catch (Exception ex)
            {
                throw _errorService.CreateException(ex, this._moduleCode, MethodsIndex.UPDATE);
            }
        }
        public void SaveToDB()
        {
            _unitOfWork.Complete();
        }

    }
}
