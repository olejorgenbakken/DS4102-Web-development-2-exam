using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace RestaurantAPI.Controllers
{

    [ApiController]
    [Route("api/dishes")]

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
                file.CopyTo(filestream);
            }
        }

        [HttpGet]
        public async Task<IEnumerable<Dish>> Get()
        {
            List<Dish> dishList = await _context.Dish.ToListAsync();
            return dishList;
        }

        [HttpPut]
        public async Task<Dish> Put(Dish updateWord)
        {
            _context.Update(updateWord);
            await _context.SaveChangesAsync();
            return updateWord;
        }

        [HttpGet("{id}")]
        public async Task<Dish> Get(int id)
        {
            Dish thisDish = await _context.Dish.FirstOrDefaultAsync(dish => dish.Id == id);
            return thisDish;
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