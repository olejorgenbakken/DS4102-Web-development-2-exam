using Microsoft.EntityFrameworkCore;

namespace RestaurantAPI.Models
{
    public class AdminsContext : DbContext
    {
        public AdminsContext(DbContextOptions<AdminsContext> options) : base(options) { }

        public DbSet<RestaurantAPI.Models.Admin> Admin { get; set; }
    }
}