using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Contract;
using Core.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GenresController : ControllerBase
    {
        private readonly IGenresService _genresService;
        public GenresController(IGenresService genresService)
        {
            _genresService = genresService;
        }
        // GET: api/Genres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenresDTO>>> Get()
        {
            try
            {
                return Ok(await _genresService.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // GET: api/Genres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GenresDTO>> Get(int id)
        {
            try
            {
                return Ok(await _genresService.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // POST: api/Genres
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GenresDTO entity)
        {
            try
            {
                return Ok(await _genresService.Add(entity));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // PUT: api/Genres/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] GenresDTO entity)
        {
            try
            {
                await _genresService.Update(entity);
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
                await _genresService.RemoveById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
