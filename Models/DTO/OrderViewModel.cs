using ShopAPI2.Models.DataBaseModels;

namespace ShopAPI2.Models.DTO
{
    public class OrderViewModel
    {
        public OrderViewModel(Order order, List<Order_ProductViewModel> products)
        {
            ID = order.ID;
            CreateOrder = order.CreateOrder;
            UserLogin = order.user.Login;
            Status = order.status.Title;
            this.products = products;
        }
        public int ID { get; private set; }
        public DateTime CreateOrder { get; set; }
        public string UserLogin { get; set; }
        public string Status { get; set; }
        public List<Order_ProductViewModel> products { get; set; }
    }
}
