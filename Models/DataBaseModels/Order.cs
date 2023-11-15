using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopAPI2.Models.DataBaseModels
{
    public class Order
    {
        [Key]
        public int ID { get; set; }
        public DateTime CreateOrder { get; set; } = DateTime.Now;
        public int IDUser { get; set; }
        public int IDStatus { get; set; }

        [ForeignKey(nameof(IDUser))]
        public User user { get; set; }

        [ForeignKey(nameof(IDStatus))]
        public Status status { get; set; }
    }
}