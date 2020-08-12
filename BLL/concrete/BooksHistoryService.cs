using BLL.Contract;
using Core.DTO;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using DAL.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Core.Shared.ErrorCodes;
using BLL.Contract.Errors;

namespace BLL.Concrete
{
    public class BooksHistoryService : AbstractGenericEntityService<BooksHistory, BooksHistoryDTO>, IBooksHistoryService
    {
        public BooksHistoryService(IUnitOfWork unitOfWork, IErrorService errorService)
            : base(unitOfWork, errorService, ModulesIndex.BOOKS_HISTORY_SERVICE)
        {
        }
        public async Task RemoveById(int id)
        {
            try
            {
                await Task.FromResult<int>(_unitOfWork.BooksHistoryRepo.RemoveById(id));
            }
            catch (Exception ex)
            {
                throw _errorService.CreateException(ex, this._moduleCode, MethodsIndex.REMOVE);
            }
        }
    }
}
