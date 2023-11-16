namespace ShopAPI2.Models.DTO
{
    public class CartDTO
    {
        public CartDTO()
        {

        }
        public CartDTO(int IDuser, List<ProductDTO?> productsDTO)
        {
            ID = IDUser;
            productsList = productsDTO ?? new List<ProductDTO>();
        }

        public int ID { get; private set; }
        public int IDUser { get; set; }
        public List<ProductDTO> productsList { get; set; }
    }
}