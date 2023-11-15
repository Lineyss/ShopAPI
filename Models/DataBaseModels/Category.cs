using System.ComponentModel.DataAnnotations;

namespace ShopAPI2.Models.DataBaseModels
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(20)]
        public string Title { get; set; }
    }
}