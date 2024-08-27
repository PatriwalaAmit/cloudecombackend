using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIUsers;
using Core.Domain.Entities;
using Core.Domain.Interface;

namespace APIUsers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUser _userService;

        public UsersController(IUser userService)
        {
            _userService = userService;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<IEnumerable<Users>> GetUsers()
        {
            return await _userService.GetAllUsers();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<Users> GetUsers(int id)
        {
            var users = await _userService.GetUserById(id);
            
            return users;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task PutUsers(int id, Users users)
        {            
            await _userService.UpdateUsers(id, users);
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task PostUsers(Users users)
        {
            await _userService.AddUsers(users);                        
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task DeleteUsers(int id)
        {           
            await _userService.DeleteUser(id);
        }        
    }
}
