using ShopAPI2.Models.DataBaseModels;
using System.ComponentModel.DataAnnotations;

namespace ShopAPI2.Models.DTO
{
    public class ProductDTO
    {
        public ProductDTO()
        {

        }

        public ProductDTO(Product product)
        {
            ID = product.ID;
            Title = product.Title;
            ImagePath = product.ImagePath;
            Description = product.Description;
            Price = product.Price;
            Count = product.Count;
            Category = product.Category.Title;
        }

        public ProductDTO(ProductPOSTDTO product)
        {
            ID = 0;
            Title = product.Title;
            ImagePath = product.Image.FileName;
            Description = product.Description;
            Price = product.Price;
            Count = product.Count;
            IDCategory = product.IDCategory;
        }

        public int GetIDCategory()
        {
            return IDCategory;
        }

        public int ID { get; private set; }
        [Required]
        [MaxLength(20)]
        public string Title { get; set; }
        [Required]
        public string ImagePath { get; set; }
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
        [Required]
        private decimal price;
        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value < 0)
                    value = 0;

                price = value;
            }
        }
        private int count;
        [Required]
        public int Count
        {
            get
            {
                return count;
            }
            set
            {
                if (value < 0)
                    value = 0;

                count = value;
            }
        }

        [Required]
        public string Category { get; set; }

        private int IDCategory { get; set; }
    }
}