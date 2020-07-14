using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Contract
{
    public interface IRolesService : IGenericEntityService<RolesDTO>
    {
        Task RemoveById(int id);
    }
}
