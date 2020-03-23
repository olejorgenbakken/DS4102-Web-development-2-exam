using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Models;

namespace RestaurantAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class DishesController : ControllerBase
    {


        private readonly DishesContext _context;

        public DishesController(DishesContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Dish>> Get()
        {
            List<Dish> dishList = await _context.Dish.ToListAsync();
            return dishList;
        }
    }

}