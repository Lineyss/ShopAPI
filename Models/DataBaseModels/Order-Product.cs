using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopAPI2.Models.DataBaseModels
{
    public class Order_Product
    {
        [Key]
        public int ID { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        [ForeignKey(nameof(OrderID))]
        public Order order { get; set; }
        [ForeignKey(nameof(ProductID))]
        public Product product { get; set; }
    }
}
