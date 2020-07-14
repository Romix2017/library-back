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
            try
            {
                return Ok(await _booksHistoryService.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // GET: api/BooksHistory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BooksHistoryDTO>> Get(int id)
        {
            try
            {
                return Ok(await _booksHistoryService.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // POST: api/BooksHistory
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] BooksHistoryDTO entity)
        {
            try
            {
                return Ok(await _booksHistoryService.Add(entity));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // PUT: api/BooksHistory/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] BooksHistoryDTO entity)
        {
            try
            {
                await _booksHistoryService.Update(entity);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _booksHistoryService.RemoveById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
