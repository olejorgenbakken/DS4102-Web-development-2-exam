using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Models
{

    public class Ingredient
    {
        [Key]
        public string Name { get; set; }
    }

}