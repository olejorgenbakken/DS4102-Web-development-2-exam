using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Models
{

    public class Dish
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public int Price { get; set; }
        public string Photo { get; set; }
        public bool Highlighted { get; set; }
    }

}