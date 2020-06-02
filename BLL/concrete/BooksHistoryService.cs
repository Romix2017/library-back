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

namespace BLL.Concrete
{
    public class BooksHistoryService : AbstractGenericEntityService<BooksHistory, BooksHistoryDTO>, IBooksHistoryService
    {
        public BooksHistoryService(IUnitOfWork unitOfWork):base(unitOfWork)
        {

        }
    }
}
