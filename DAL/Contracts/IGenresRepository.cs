﻿using Core.DTO;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Contracts
{
    public interface IGenresRepository : IRepository<Genres, GenresDTO>
    {
        int RemoveById(int id);
    }
}
