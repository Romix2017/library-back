using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IBooksRepository BooksRepo { get; }
        IBooksHistoryRepository BooksHistoryRepo { get; }
        IGenresRepository GenresRepo { get; }
        IRolesRepository RolesRepo { get; }
        IUsersRepository UsersRepo { get; }
        IRepository<T, TDto> GetRepo<T, TDto>(Type entity) where T : class where TDto : class;
        int Complete();
    }
}
