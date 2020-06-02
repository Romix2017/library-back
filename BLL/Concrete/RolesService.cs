using BLL.Contract;
using Core.DTO;
using DAL.Contracts;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Concrete
{
    public class RolesService : AbstractGenericEntityService<Roles, RolesDTO>, IRolesService
    {
        public RolesService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
