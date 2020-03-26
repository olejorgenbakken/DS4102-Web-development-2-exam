using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Models;
using System.Linq;

namespace RestaurantAPI.Controllers
{

    [ApiController]
    [Route("api/admins")]

    public class AdminsController : ControllerBase
    {


        private readonly RestaurantsContext _context;

        public AdminsController(RestaurantsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Admin>> Get()
        {
            List<Admin> AdminList = await _context.Admin.ToListAsync();
            return AdminList;
        }

        [HttpGet("{id}")]
        public async Task<Admin> Get(int id)
        {
            Admin thisAdmin = await _context.Admin.FirstOrDefaultAsync(admin => admin.Id == id);
            return thisAdmin;
        }
    }

}