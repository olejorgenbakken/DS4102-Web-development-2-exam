using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Models
{

    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string Items { get; set; }
        public int Total { get; set; }
        public string UserEmail { get; set; }

        public string Date { get; set; }
    }

}