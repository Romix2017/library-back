﻿using System;
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
            try
            {
                return Ok(await _booksService.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BooksDTO>> Get(int id)
        {
            try
            {
                return Ok(await _booksService.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // POST: api/Books
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] BooksDTO entity)
        {
            try
            {
                await _booksService.Add(entity);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // PUT: api/Books/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] BooksDTO value)
        {
            try
            {
                await _booksService.Update(value);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public async Task<ActionResult> Delete(BooksDTO entity)
        {
            try
            {
                await _booksService.Remove(entity);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
