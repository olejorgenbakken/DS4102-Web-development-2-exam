using Microsoft.EntityFrameworkCore;

namespace RestaurantAPI.Models
{
    public class DishesContext : DbContext
    {
        public DishesContext(DbContextOptions<DishesContext> options) : base(options) { }

        public DbSet<RestaurantAPI.Models.Dish> Dish { get; set; }
    }
}