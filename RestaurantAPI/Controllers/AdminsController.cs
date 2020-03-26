using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Models;

namespace RestaurantAPI.Controllers
{

    [ApiController]
    [Route("api/admins")]

    public class AdminsController : ControllerBase
    {


        private readonly AdminsContext _context;

        public AdminsController(AdminsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Admin>> Get()
        {
            List<Admin> AdminList = await _context.Admin.ToListAsync();
            return AdminList;
        }
    }

}