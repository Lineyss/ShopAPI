using System.ComponentModel.DataAnnotations;

namespace ShopAPI2.Models.DTO
{
    public class ProductPOSTDTO
    {
        [Required]
        [MaxLength(20)]
        public string Title { get; set; }
        [Required]
        public IFormFile Image { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public int IDCategory { get; set; }
    }
}
