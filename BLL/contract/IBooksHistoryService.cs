using Core.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Contract
{
    public interface IBooksHistoryService : IGenericEntityService<BooksHistoryDTO>
    {
    }

}
