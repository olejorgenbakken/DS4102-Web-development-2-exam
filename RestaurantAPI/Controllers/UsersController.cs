using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Models;

namespace RestaurantAPI.Controllers
{

    [ApiController]
    [Route("users")]

    public class UsersController : ControllerBase
    {
        private readonly RestaurantsContext _context;

        public UsersController(RestaurantsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            List<User> UserList = await _context.User.ToListAsync();
            return UserList;
        }

        [HttpGet("id/{id}")]
        public async Task<User> Get(int id)
        {
            User thisUser = await _context.User.FirstOrDefaultAsync(user => user.Id == id);
            return thisUser;
        }

        [HttpGet("{email}")]
        public async Task<User> Get(string email)
        {
            User thisUser = await _context.User.FirstOrDefaultAsync(user => user.Email == email);
            return thisUser;
        }

        [HttpPost]
        public async Task<User> Post(User newUser)
        {
            _context.User.Add(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }

        [HttpPut]
        public async Task<User> Put(User updateUser)
        {
            _context.Update(updateUser);
            await _context.SaveChangesAsync();
            return updateUser;
        }

        [HttpDelete("{id}")]
        public async Task<User> Delete(int id)
        {
            User userToDelete = await _context.User.FirstOrDefaultAsync(user => user.Id == id);
            _context.Remove(userToDelete);
            await _context.SaveChangesAsync();
            return userToDelete;
        }
    }
}