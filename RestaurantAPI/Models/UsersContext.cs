using Microsoft.EntityFrameworkCore;

namespace RestaurantAPI.Models
{
    public class UsersContext : DbContext
    {
        public UsersContext(DbContextOptions<UsersContext> options) : base(options) { }

        public DbSet<RestaurantAPI.Models.User> User { get; set; }
    }
}