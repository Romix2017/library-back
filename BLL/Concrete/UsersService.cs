﻿using BLL.Contract;
using Core.DTO;
using DAL.Contracts;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Concrete
{
    public class UsersService : AbstractGenericEntityService<Users, UsersDTO>, IUsersService
    {
        public UsersService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
