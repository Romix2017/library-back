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
            return await _rolesService.GetAll();
        }

        // GET: api/Roles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RolesDTO>> Get(int id)
        {
            return await _rolesService.GetById(id);
        }

        // POST: api/Roles
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RolesDTO entity)
        {
            return await _rolesService.Add(entity);
        }

        // PUT: api/Roles/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] RolesDTO entity)
        {
            return await _rolesService.Update(entity);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(RolesDTO entity)
        {
            return await _rolesService.Remove(entity);
        }
    }
}
