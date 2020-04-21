using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Models
{

    public class DishType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }

}