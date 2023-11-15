using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopAPI2.Models.DataBaseModels
{
    public class Product
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(20)]
        public string Title { get; set; }

        [Required]
        public string ImagePath { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public bool IsExist { get; set; } = false;

        [Required]
        public int IDCategory { get; set; }

        [Required]
        [ForeignKey(nameof(IDCategory))]
        public Category Category { get; set; }
    }
}
