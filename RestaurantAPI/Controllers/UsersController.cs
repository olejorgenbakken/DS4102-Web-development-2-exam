using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Models;

namespace RestaurantAPI.Controllers
{

    [ApiController]
    [Route("api/users")]

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

        [HttpGet("{id}")]
        public async Task<User> Get(int id)
        {
            User thisUser = await _context.User.FirstOrDefaultAsync(user => user.Id == id);
            return thisUser;
        }

        [HttpGet("user/{name}")]
        public async Task<User> Get(string name)
        {
            User thisUser = await _context.User.FirstOrDefaultAsync(user => user.Username == name);
            return thisUser;
        }
    }
}