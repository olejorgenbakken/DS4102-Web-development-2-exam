using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Models;

namespace RestaurantAPI.Controllers
{

    [ApiController]
    [Route("api/dishes")]

    public class DishesController : ControllerBase
    {


        private readonly RestaurantsContext _context;

        public DishesController(RestaurantsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Dish>> Get()
        {
            List<Dish> dishList = await _context.Dish.ToListAsync();
            return dishList;
        }

        [HttpGet("{id}")]
        public async Task<Dish> Get(int id)
        {
            Dish thisDish = await _context.Dish.FirstOrDefaultAsync(dish => dish.Id == id);
            return thisDish;
        }
    }

}