using BLL.Contract;
using Core.DTO;
using DAL.Contracts;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Concrete
{
    public class BooksService : AbstractGenericEntityService<Books, BooksDTO>, IBooksService
    {
        public BooksService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
