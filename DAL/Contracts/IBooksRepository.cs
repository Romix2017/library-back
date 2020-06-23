using Core.DTO;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Contracts
{
    public interface IBooksRepository : IRepository<Books, BooksDTO>
    {
        int RemoveById(int id);
    }
}
