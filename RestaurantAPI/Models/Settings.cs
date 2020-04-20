using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Models
{

    public class Settings
    {
        [Key]
        public int Id { get; set; }
        public string Color { get; set; }
        public string Text { get; set; }
    }

}