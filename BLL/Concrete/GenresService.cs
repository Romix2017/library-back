using BLL.Contract;
using BLL.Contract.Errors;
using Core.DTO;
using Core.Shared.ErrorCodes;
using DAL.Contracts;
using DAL.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class GenresService : AbstractGenericEntityService<Genres, GenresDTO>, IGenresService
    {
        public GenresService(IUnitOfWork unitOfWork, IErrorService errorService)
            : base(unitOfWork, errorService, ModulesIndex.GENRES_SERVICE)
        {

        }
        public async Task RemoveById(int id)
        {
            try
            {
                await Task.FromResult<int>(_unitOfWork.GenresRepo.RemoveById(id));
            }
            catch (Exception ex)
            {
                throw _errorService.CreateException(ex, this._moduleCode, MethodsIndex.REMOVE);
            }
        }
    }
}
