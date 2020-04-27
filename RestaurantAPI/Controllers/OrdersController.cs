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
    [Route("orders")]

    public class OrdersController : ControllerBase
    {


        private readonly RestaurantsContext _context;
        private readonly IWebHostEnvironment _hosting;

        public OrdersController(RestaurantsContext context, IWebHostEnvironment hosting)
        {
            _context = context;
            _hosting = hosting;
        }

        [HttpPost]
        public async Task<Order> Post(Order newOrder)
        {
            _context.Order.Add(newOrder);
            await _context.SaveChangesAsync();
            return newOrder;
        }

        [HttpGet]
        public async Task<IEnumerable<Order>> Get()
        {
            List<Order> orderList = await _context.Order.ToListAsync();
            return orderList;
        }

        [HttpPut]
        public async Task<Order> Put(Order updateOrder)
        {
            _context.Update(updateOrder);
            await _context.SaveChangesAsync();
            return updateOrder;
        }

        [HttpGet("{id}")]
        public async Task<Order> Get(int id)
        {
            Order thisOrder = await _context.Order.FirstOrDefaultAsync(order => order.Id == id);
            return thisOrder;
        }

        [HttpDelete("{id}")]
        public async Task<Order> Delete(int id)
        {
            Order orderToDelete = await _context.Order.FirstOrDefaultAsync(order => order.Id == id);
            _context.Remove(orderToDelete);
            await _context.SaveChangesAsync();
            return orderToDelete;
        }
    }

}