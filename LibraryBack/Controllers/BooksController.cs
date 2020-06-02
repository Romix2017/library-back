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
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;
        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }
        // GET: api/Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BooksDTO>>> Get()
        {
            return await _booksService.GetAll();
        }
        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BooksDTO>> Get(int id)
        {
            return await _booksService.GetById(id);
        }

        // POST: api/Books
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] BooksDTO entity)
        {
            return await _booksService.Add(entity);
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] BooksDTO value)
        {
            return await _booksService.Update(value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(BooksDTO entity)
        {
            return await _booksService.Remove(entity);
        }
    }
}
