using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopAPI2.Models.DataBaseModels
{
    public class Cart
    {
        [Key]
        public int ID { get; set; }
        public int IDUser { get; set; }
        public int IDProduct { get; set; }
        public int CountProduct { get; set; }
        [Required]
        [ForeignKey(nameof(IDUser))]
        public User User { get; set; }
        [Required]
        [ForeignKey(nameof(IDProduct))]
        public Product Product { get; set; }
    }
}
