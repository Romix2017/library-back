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
            return await _genresService.GetAll();
        }

        // GET: api/Genres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GenresDTO>> Get(int id)
        {
            return await _genresService.GetById(id);
        }

        // POST: api/Genres
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] GenresDTO entity)
        {
            return await _genresService.Add(entity);
        }

        // PUT: api/Genres/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] GenresDTO entity)
        {
            return await _genresService.Update(entity);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(GenresDTO entity)
        {
            return await _genresService.Remove(entity);
        }
    }
}
