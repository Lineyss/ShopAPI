using ShopAPI2.Models.DataBaseModels;

namespace ShopAPI2.Models.DTO
{
    public class Order_ProductViewModel
    {
        public Order_ProductViewModel(Order_Product order_Product)
        {
            ID = order_Product.ID;
            Count = order_Product.Count;
            Price = order_Product.Price;
            Product = order_Product.product.Title;
            OrderID = order_Product.OrderID;
        }

        public int ID { get; private set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public string Product { get; set; }
        public int OrderID { get; set; }

    }
}
