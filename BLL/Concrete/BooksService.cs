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

namespace BLL.Concrete
{
    public class BooksService : AbstractGenericEntityService<Books, BooksDTO>, IBooksService
    {
        public BooksService(IUnitOfWork unitOfWork, IErrorService errorService) 
            : base(unitOfWork, errorService, ModulesIndex.BOOK_SERVICE)
        {
        }
    }
}
