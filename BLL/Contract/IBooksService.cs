using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Contract
{
    public interface IBooksService : IGenericEntityService<BooksDTO>
    {
        Task RemoveById(int id);
    }
}
