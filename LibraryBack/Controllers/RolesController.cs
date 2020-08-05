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
    public class RolesController : ControllerBase
    {
        private readonly IRolesService _rolesService;
        public RolesController(IRolesService rolesService)
        {
            _rolesService = rolesService;
        }
        // GET: api/Roles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RolesDTO>>> Get()
        {
            try
            {
                return Ok(await _rolesService.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // GET: api/Roles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RolesDTO>> Get(int id)
        {
            try
            {
                return Ok(await _rolesService.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }

        // POST: api/Roles
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RolesDTO entity)
        {
            try
            {
                return Ok(await _rolesService.Add(entity));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // PUT: api/Roles/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] RolesDTO entity)
        {
            try
            {
                await _rolesService.Update(entity);
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
                await _rolesService.RemoveById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
