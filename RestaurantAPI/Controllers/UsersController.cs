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


        private readonly UsersContext _context;

        public UsersController(UsersContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            List<User> UserList = await _context.User.ToListAsync();
            return UserList;
        }
    }

}