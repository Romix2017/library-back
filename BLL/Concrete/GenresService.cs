﻿using BLL.Contract;
using Core.DTO;
using DAL.Contracts;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Concrete
{
    public class GenresService : AbstractGenericEntityService<Genres, GenresDTO>, IGenresService
    {
        public GenresService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
    }
}
