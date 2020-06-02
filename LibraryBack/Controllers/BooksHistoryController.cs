using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Contract;
using Core.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksHistoryController : ControllerBase
    {
        private readonly IBooksHistoryService _booksHistoryService;
        public BooksHistoryController(IBooksHistoryService booksHistoryService)
        {
            _booksHistoryService = booksHistoryService;
        }
        // GET: api/BooksHistory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BooksHistoryDTO>>> Get()
        {
            return await _booksHistoryService.GetAll();
        }

        // GET: api/BooksHistory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BooksHistoryDTO>> Get(int id)
        {
            return await _booksHistoryService.GetById(id);
        }

        // POST: api/BooksHistory
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] BooksHistoryDTO entity)
        {
            return await _booksHistoryService.Add(entity);
        }

        // PUT: api/BooksHistory/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] BooksHistoryDTO entity)
        {
            return await _booksHistoryService.Update(entity);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(BooksHistoryDTO entity)
        {
            return await _booksHistoryService.Remove(entity);
        }
    }
}
