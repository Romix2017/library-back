﻿using Core.DTO;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Contracts
{
    public interface IRolesRepository : IRepository<Roles, RolesDTO>
    {
        int RemoveById(int id);
    }
}
