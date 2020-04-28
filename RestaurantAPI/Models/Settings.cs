using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Models
{

    public class Settings
    {
        [Key]
        public int Id { get; set; }
        public string Logo { get; set; }
        public string Highlighted { get; set; }
        public string HighlightedText { get; set; }
    }

}