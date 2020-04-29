using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using System;
using Microsoft.AspNetCore.Hosting;

namespace RestaurantAPI.Controllers
{

    [ApiController]
    [Route("dishes")]

    public class DishesController : ControllerBase
    {
        private readonly RestaurantsContext _context;
        private readonly IWebHostEnvironment _hosting;

        public DishesController(RestaurantsContext context, IWebHostEnvironment hosting)
        {
            _context = context;
            _hosting = hosting;
        }

        [HttpPost]
        public async Task<Dish> Post(Dish newDish)
        {
            _context.Dish.Add(newDish);
            await _context.SaveChangesAsync();
            return newDish;
        }

        [HttpPost]
        [Route("[action]")]
        public void Upload(IFormFile file)
        {
            string webrootpath = _hosting.WebRootPath;
            string absolutepath = Path.Combine($"{webrootpath}/images/{file.FileName}");

            using (var filestream = new FileStream(absolutepath, FileMode.Create))
            {
                try
                {
                    file.CopyTo(filestream);

                }
                catch (System.IO.DirectoryNotFoundException)
                {
                    Console.Write("You need to create the wwwroot/images directory within the API");
                }
            }
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

        [HttpGet("highlighted/{highlighted}")]
        public async Task<Dish> Get(bool highlighted)
        {
            Dish highlightedDish = await _context.Dish.FirstOrDefaultAsync(dish => dish.Highlighted == highlighted);
            return highlightedDish;
        }

        [HttpPut]
        public async Task<Dish> Put(Dish updateDish)
        {
            _context.Update(updateDish);
            await _context.SaveChangesAsync();
            return updateDish;
        }

        [HttpDelete("{id}")]
        public async Task<Dish> Delete(int id)
        {
            Dish dishToDelete = await _context.Dish.FirstOrDefaultAsync(dish => dish.Id == id);
            _context.Remove(dishToDelete);
            await _context.SaveChangesAsync();
            return dishToDelete;
        }
    }

}