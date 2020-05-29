using BLL.contract;
using Core.DTO;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using DAL.Contracts;
using Microsoft.AspNetCore.Http;

namespace BLL.concrete
{
    public class BooksHistoryService : IBooksHistoryService<Books, BooksDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        public BooksHistoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ActionResult> Add(Books entity)
        {
            try
            {
                await Task.FromResult<Books>(_unitOfWork.BooksRepo.Add(entity));
                return new OkResult();
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ActionResult> AddRange(IEnumerable<Books> entities)
        {
            try
            {
                await Task.FromResult<IEnumerable<Books>>(_unitOfWork.BooksRepo.AddRange(entities));
                return new OkResult();
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ActionResult<IEnumerable<Books>>> Find(Expression<Func<Books, bool>> predicate)
        {
            try
            {
                return new OkObjectResult(await _unitOfWork.BooksRepo.Find(predicate));
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ActionResult<IEnumerable<BooksDTO>>> GetAll()
        {
            try
            {
                return new OkObjectResult(await _unitOfWork.BooksRepo.GetAll());
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ActionResult<Books>> GetById(int id)
        {
            try
            {
                return new OkObjectResult(await _unitOfWork.BooksRepo.GetById(id));
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ActionResult> Remove(Books entity)
        {
            try
            {
                await Task.FromResult<Books>(_unitOfWork.BooksRepo.Remove(entity));
                return new OkResult();
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        public async Task<ActionResult> RemoveRange(IEnumerable<Books> entities)
        {
            try
            {
                await Task.FromResult<IEnumerable<Books>>(_unitOfWork.BooksRepo.RemoveRange(entities));
                return new OkResult();
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
