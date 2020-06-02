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
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }
        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsersDTO>>> Get()
        {
            return await _usersService.GetAll();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsersDTO>> Get(int id)
        {
            return await _usersService.GetById(id);
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UsersDTO entity)
        {
            return await _usersService.Add(entity);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] UsersDTO entity)
        {
            return await _usersService.Update(entity);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(UsersDTO entity)
        {
            return await _usersService.Remove(entity);
        }
    }
}
