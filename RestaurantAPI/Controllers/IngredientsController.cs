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
    [Route("ingredients")]

    public class IngredientsController : ControllerBase
    {


        private readonly RestaurantsContext _context;
        private readonly IWebHostEnvironment _hosting;

        public IngredientsController(RestaurantsContext context, IWebHostEnvironment hosting)
        {
            _context = context;
            _hosting = hosting;
        }

        [HttpPost]
        public async Task<Ingredient> Post(Ingredient newIngredient)
        {
            _context.Ingredient.Add(newIngredient);
            await _context.SaveChangesAsync();
            return newIngredient;
        }

        [HttpGet]
        public async Task<IEnumerable<Ingredient>> Get()
        {
            List<Ingredient> ingredientList = await _context.Ingredient.ToListAsync();
            return ingredientList;
        }

        [HttpGet("{name}")]
        public async Task<Ingredient> Get(string name)
        {
            Ingredient thisIngredient = await _context.Ingredient.FirstOrDefaultAsync(ingredient => ingredient.Name == name);
            return thisIngredient;
        }

        [HttpDelete("{name}")]
        public async Task<Ingredient> Delete(string name)
        {
            Ingredient ingredientToDelete = await _context.Ingredient.FirstOrDefaultAsync(ingredient => ingredient.Name == name);
            _context.Remove(ingredientToDelete);
            await _context.SaveChangesAsync();
            return ingredientToDelete;
        }
    }

}