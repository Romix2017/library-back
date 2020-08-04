using BLL.Contract;
using BLL.Contract.Errors;
using Core.Shared.ErrorCodes;
using Core.Shared.helpers;
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
        public async Task<TDto> Add(TDto entity)
        {
            try
            {
                return await Task.FromResult<TDto>(_unitOfWork.GetRepo<T, TDto>(typeof(TDto)).AddDTO(entity));
            }
            catch (Exception ex)
            {
                throw _errorService.CreateException(ex, this._moduleCode, MethodsIndex.ADD);
            }
        }

        public async Task AddRange(IEnumerable<TDto> entities)
        {
            try
            {
                await Task.FromResult<IEnumerable<TDto>>(_unitOfWork.GetRepo<T, TDto>(typeof(TDto)).AddRangeDTO(entities));
                SaveToDB();
            }
            catch (Exception ex)
            {
                throw _errorService.CreateException(ex, this._moduleCode, MethodsIndex.ADD_RANGE);
            }
        }

        public async Task<IEnumerable<TDto>> GetAll()
        {
            try
            {
                return await _unitOfWork.GetRepo<T, TDto>(typeof(TDto)).GetAllDTO();
            }
            catch (Exception ex)
            {
                throw _errorService.CreateException(ex, this._moduleCode, MethodsIndex.GET_ALL);
            }
        }

        public async Task<TDto> GetById(int id)
        {
            try
            {
                return await _unitOfWork.GetRepo<T, TDto>(typeof(TDto)).GetByIdDTO(id);
            }
            catch (Exception ex)
            {
                throw _errorService.CreateException(ex, this._moduleCode, MethodsIndex.GET_BY_ID);
            }
        }

        public async Task Remove(TDto entity)
        {
            try
            {
                await Task.FromResult<TDto>(_unitOfWork.GetRepo<T, TDto>(typeof(TDto)).RemoveDTO(entity));
                SaveToDB();
            }
            catch (Exception ex)
            {
                throw _errorService.CreateException(ex, this._moduleCode, MethodsIndex.REMOVE);
            }
        }

        public async Task RemoveRange(IEnumerable<TDto> entities)
        {
            try
            {
                await Task.FromResult<IEnumerable<TDto>>(_unitOfWork.GetRepo<T, TDto>(typeof(TDto)).RemoveRangeDTO(entities));
                SaveToDB();
            }
            catch (Exception ex)
            {
                throw _errorService.CreateException(ex, this._moduleCode, MethodsIndex.REMOVE_RANGE);
            }
        }

        public async Task Update(TDto entity)
        {
            try
            {
                await Task.FromResult<TDto>(_unitOfWork.GetRepo<T, TDto>(typeof(TDto)).UpdateDTO(entity));
                SaveToDB();
            }
            catch (Exception ex)
            {
                throw _errorService.CreateException(ex, this._moduleCode, MethodsIndex.UPDATE);
            }
        }
        public void SaveToDB()
        {
            _unitOfWork.GetRepo<T, TDto>(typeof(TDto)).Complete();
        }
        public void DisposeDB()
        {
            _unitOfWork.GetRepo<T, TDto>(typeof(TDto)).Dispose();
        }
    }
}
