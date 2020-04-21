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
    [Route("dishtypes")]

    public class DishTypesController : ControllerBase
    {


        private readonly RestaurantsContext _context;
        private readonly IWebHostEnvironment _hosting;

        public DishTypesController(RestaurantsContext context, IWebHostEnvironment hosting)
        {
            _context = context;
            _hosting = hosting;
        }

        [HttpPost]
        public async Task<DishType> Post(DishType newType)
        {
            _context.DishType.Add(newType);
            await _context.SaveChangesAsync();
            return newType;
        }

        [HttpGet]
        public async Task<IEnumerable<DishType>> Get()
        {
            List<DishType> typeList = await _context.DishType.ToListAsync();
            return typeList;
        }

        [HttpPut]
        public async Task<DishType> Put(DishType updateType)
        {
            _context.Update(updateType);
            await _context.SaveChangesAsync();
            return updateType;
        }

        [HttpGet("{id}")]
        public async Task<DishType> Get(int id)
        {
            DishType thisType = await _context.DishType.FirstOrDefaultAsync(type => type.Id == id);
            return thisType;
        }

        [HttpDelete("{name}")]
        public async Task<DishType> Delete(string name)
        {
            DishType typeToDelete = await _context.DishType.FirstOrDefaultAsync(type => type.Name == name);
            _context.Remove(typeToDelete);
            await _context.SaveChangesAsync();
            return typeToDelete;
        }
    }

}