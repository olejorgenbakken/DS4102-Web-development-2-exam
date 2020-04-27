using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Models
{

    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string Items { get; set; }
        public string User { get; set; }
    }

}