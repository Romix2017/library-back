using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Contract;
using BLL.Contract.Authorization;
using Core.DTO;
using LibraryBack.Shared.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = Policy.MainUsersGroup)]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        private readonly IUserAuthService _usersAuthService;
        public UsersController(IUsersService usersService, IUserAuthService usersAuthService)
        {
            _usersService = usersService;
            _usersAuthService = usersAuthService;

        }
        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsersDTO>>> Get()
        {
            try
            {
                return Ok(await _usersService.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsersDTO>> Get(int id)
        {
            try
            {
                return Ok(await _usersService.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UsersDTO entity)
        {
            try
            {
                return Ok(await _usersAuthService.CreateFull(entity));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // PUT: api/Users/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UsersDTO entity)
        {
            try
            {
                await _usersService.Update(entity);
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
                await _usersService.RemoveById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
